using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // This class manages wether a draggable cube should be spawned.

    bool spawn = true;

    bool trash = false;

    // These gameObjects will be used for their positions for the tiles to spawn in UiSpawn
    public GameObject wetlandPos;
    public GameObject bioswalePos;
    public GameObject housePos;
    public GameObject roadPos;
    public GameObject mainSpawn;

    // This stack will keep track of the moves that have been made
    Hashtable snapBack = new Hashtable();

    Stack<GameObject> back = new Stack<GameObject>();
    // move will be used when the player wishes to undo their move; it will become the move popped off the stack
    MoveProperties move;

    //public float[,] gridPositions;
    public TileValues.TileType[,] gridTiles;                // 2D grid that stores tile values at each location

    // scoring 
    public Scoring scoreCalculator;                         // object used to calculate score based on tile arrangement on grid
    public Scoreholder totalScore;                          // object used to store total scores/descriptions for each of the 3 goals
    public List<Scoreholder> scoreList;                     // list that stores up to 4 adjacent interactions of most recently placed tile 

    public GameObject scoreDisplay;                         // gameObject UI that displays the score
    public ScoreDisplayController scoreDisplayController;   // script used to control score UI

    public GameObject floodGoal;                            // gameObject UI that displays the flood goal progress                          
    public FloodGoalController floodGoalController;         // script used to control flood goal
    public GameObject housingGoal;                          // gameObject UI that displays the housing goal progress 
    public HousingGoalController housingGoalController;     // script used to control housing goal
    public GameObject pedSafetyGoal;                        // gameObject UI that displays the pedestrian safety goal progress 
    public PedSafetyGoalController pedSafetyGoalController; // script used to control pedestrian safety goal

    public GameObject canvas;                               // gameObject that contains all UI elements
    public ScorePanelManager scorePanelManager;             // script used to control the scorepanel visibility and content
    
    public 

    void Start()
    {        
        // initiate grid with empty tile values
        gridTiles = new TileValues.TileType[5, 5];
        TileValues noneTileValues = new TileValues();               // "none" type means no tile is present at this location of the grid
        noneTileValues.AssignValues(0, TileValues.TileType.none);
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {
                gridTiles[j, i] = TileValues.TileType.none;
            }
        }
        // scoring class used for calculating score and block interaction
        scoreCalculator = new Scoring();

        // find all UI gameobjects in the game hierarchy and access their scripts 
        scoreDisplay = GameObject.Find("Canvas/Score");                                 // find the score display gameobject
        scoreDisplayController = scoreDisplay.GetComponent<ScoreDisplayController>();   // access scoreDisplayController script

        floodGoal = GameObject.Find("Canvas/Goals/Flood Progress Bar");                 // find the flood goal gameobject
        floodGoalController = floodGoal.GetComponent<FloodGoalController>();            // access the flood goal controller script 
        housingGoal = GameObject.Find("Canvas/Goals/Housing Progress Bar");             // find the housing goal gameobject
        housingGoalController = housingGoal.GetComponent<HousingGoalController>();      // access the housing goal controller script 
        pedSafetyGoal = GameObject.Find("Canvas/Goals/PedSafety Progress Bar");         // find the pedSafety goal gameobject
        pedSafetyGoalController = pedSafetyGoal.GetComponent<PedSafetyGoalController>();// access the pedSafety goal controller script 
        
        canvas = GameObject.Find("Canvas");                                             // find the canvas gameobject
        scorePanelManager = canvas.GetComponent<ScorePanelManager>();                   // access the scorepanelmanager script attached to canvas
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // manually update score for debugging purposes
            totalScore = CalcScore(gridTiles);
            scoreDisplayController.updateScore(totalScore);

            foreach (DictionaryEntry d in snapBack)
                Debug.Log("Key: " + d.Key.ToString() + ", Value: " + d.Value.ToString());
        }
    }

    // allows for adding an element to a data structure without changed other code
    public void AddElement(MoveProperties move, string placement, TileValues.TileType tileValues)
    {
        // get location of tile placement on the grid
        int col = (int)Char.GetNumericValue(placement[0]);
        int row = (int)Char.GetNumericValue(placement[2]);

        // store current tile's values in its corresponding location on the tile values grid 
        gridTiles[col, row] = tileValues;

        // calculate score based on current tiles on grid and display on UI
        totalScore = CalcScore(gridTiles);                 
        scoreDisplayController.updateScore(totalScore);     // update total score UI
        floodGoalController.updateScore(totalScore);        // update flood goal UI
        housingGoalController.updateScore(totalScore);      // update housing/quality of life goal UI
        pedSafetyGoalController.updateScore(totalScore);    // update ped safety goal UI

        // get list of interactions between most recently placed tile and adjacent blocks 
        scoreList = scoreCalculator.GetCurrentTileScores(gridTiles, col, row);
        if (scoreList.Count() > 0)
        {
            Debug.Log("Begin list");
            foreach (Scoreholder score in scoreList)
            {
                Debug.Log("Interaction: " + score.tileOne.ToString() + ", " + score.tileTwo.ToString());
            }
            Debug.Log("End list");
        }
    }

    public void snap(string gridSpot)
    {
        snapBack.Add(gridSpot, gridSpot);
    }

    public void addThing(GameObject gridSpot)
    {
        back.Push(gridSpot);
        Debug.Log("add thing: " + gridSpot.name);
    }

    public GameObject backThing()
    {
        return back.Pop();
    }

    public bool test()
    {
        return back.Count == 0;
    }

    //public void Undo()
    //{
    //    move = moves.Pop();
    //    move.UndoMove();
    //    Debug.Log(move.objPos);
    //    Debug.Log(move.replacementObj.name);
    //    Debug.Log(move.gameObj.name);
    //}

    public void Undo(string placement)
    {
        int col = (int)Char.GetNumericValue(placement[0]);
        int row = (int)Char.GetNumericValue(placement[2]);

        //gridPositions[col, row] = 0f;

        TileValues tileValues = new TileValues();
        tileValues.AssignValues(0, TileValues.TileType.none);
        gridTiles[col, row] = tileValues.type;

        Debug.Log("tile removed from grid.");

        // calculate score based on current tiles on grid and display on UI
        totalScore = CalcScore(gridTiles);
        scoreDisplayController.updateScore(totalScore);
        floodGoalController.updateScore(totalScore);        // update flood goal UI
        housingGoalController.updateScore(totalScore);      // update housing/quality of life goal UI
        pedSafetyGoalController.updateScore(totalScore);    // update ped safety goal UI

        // get list of interactions between most recently placed tile and adjacent blocks
        scoreList = scoreCalculator.GetCurrentTileScores(gridTiles, col, row);
        if (scoreList.Count() > 0)
        {
            Debug.Log("Begin list");
            foreach (Scoreholder score in scoreList)
            {
                Debug.Log("Interaction: " + score.tileOne.ToString() + ", " + score.tileTwo.ToString());
            }
            Debug.Log("End list");
        }

    }

    public bool GetSpawn()
    {
        return spawn;
    }

    public void SetSpawn(bool x)
    {
        spawn = x;
    }

    public bool GetTrash()
    {
        return trash;
    }

    public void SetTrash(bool x)
    {
        trash = x;
    }


    public Scoreholder CalcScore(TileValues.TileType[,] gridTiles)
    {
        Scoreholder totalScores = scoreCalculator.GetScore(gridTiles);
        Debug.Log("total score: ");
        totalScores.printScore();
        return totalScores;
    }
}
