using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring
{

    // calculate score between two blocks 
    public void GetScore(TileValues[,] gridTiles)
    {
        Scoreholder totalScores = new Scoreholder();    // stores total score 
        Scoreholder scoreholder = new Scoreholder();    // stores current tile interaction's score and description

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                // tile is at corner of grid
                if (i == 4 && j == 4)
                {
                    // skip tile- already been calculated
                    Debug.Log("corner" + i + "," + j);
                }
                // tile is at edge- only perform calculation with block +1 j over, not +1 i
                else if (i == 4)
                {
                    // get flood score with tile next to it (+1 j)
                    Debug.Log("i edge" + i + "," + j);
                    scoreholder = GetInteractions(gridTiles[i, j], gridTiles[i, j + 1]);
                }
                // tile is at edge- only perform calculation with block +1 i over, not +1 j
                else if (j == 4)
                {
                    // get flood score with block below it (+1 i)
                    Debug.Log("j edge." + i + "," + j);
                    scoreholder = GetInteractions(gridTiles[i, j], gridTiles[i+1, j]);
                }
                // current tile should have a tile below and next to it 
                else
                {
                    Debug.Log("non-edge" + i + "," + j);
                    //get flood score with block next to it (+1 j)
                    scoreholder = GetInteractions(gridTiles[i, j], gridTiles[i, j+1]);
                    //get flood score with block below it (+1 i)
                    scoreholder = GetInteractions(gridTiles[i, j], gridTiles[i + 1, j]);
                }
                // add scores from current tile interaction to total scores 
                totalScores.floodPts += scoreholder.floodPts;
                totalScores.pedSafetyPts += scoreholder.pedSafetyPts;
                totalScores.qualLifePts += scoreholder.qualLifePts;
            }
        }

    }

    public Scoreholder GetInteractions(TileValues tileOne, TileValues tileTwo)
    {
        /*Debug.Log("Interaction: " + tileOne.type + ", " + tileTwo.type);*/
        Scoreholder scoreholder = new Scoreholder();
        
        switch(tileOne.type)
        {
            case TileValues.TileType.road:
                //check interactions with all types
                switch (tileTwo.type)
                {
                    case TileValues.TileType.road:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = 0f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "missing";
                        scoreholder.floodDesc = "missing";
                        scoreholder.qualLifeDesc = "missing";
                        break;
                    case TileValues.TileType.wetlands:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = 0f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "missing";
                        scoreholder.floodDesc = "missing";
                        scoreholder.qualLifeDesc = "missing";
                        break;
                    case TileValues.TileType.bioswale:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = 0f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "missing";
                        scoreholder.floodDesc = "missing";
                        scoreholder.qualLifeDesc = "missing";
                        break;
                    case TileValues.TileType.house:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = 0f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "missing";
                        scoreholder.floodDesc = "missing";
                        scoreholder.qualLifeDesc = "missing";
                        break;
                    case TileValues.TileType.none:
                        //skip empty tile
                        break;
                }
                break;
            case TileValues.TileType.wetlands:
                //check interactions with all types
                switch (tileTwo.type)
                {
                    case TileValues.TileType.road:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = 0f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "missing";
                        scoreholder.floodDesc = "missing";
                        scoreholder.qualLifeDesc = "missing";
                        break;
                    case TileValues.TileType.wetlands:
                        scoreholder.pedSafetyPts = -10f;
                        scoreholder.floodPts = 30f;
                        scoreholder.qualLifePts = 20f;
                        scoreholder.pedSafetyDesc = "missing";
                        scoreholder.floodDesc = "Water reservoirs";
                        scoreholder.qualLifeDesc = "Recreation: Physical activities";
                        break;
                    case TileValues.TileType.bioswale:
                        scoreholder.pedSafetyPts = -10f;
                        scoreholder.floodPts = -15f;
                        scoreholder.qualLifePts = 30f;
                        scoreholder.pedSafetyDesc = "High level maintenance: Blockage, ponding, overgrowth, frequent inspection.";
                        scoreholder.floodDesc = "Flow restrictions:Trash and debris left to accumulate in either the storm drainage system leading to restrict the flow of water causing localized flooding and possible erosion, create sediment buildup, and create aesthetic problems that create poor public perception of the site.";
                        scoreholder.qualLifeDesc = "Habitat diversity: Creating new forms of habitat diversity than those displaced by construction, but are beneficial (e.g. wildlife species and insects).";
                        break;
                    case TileValues.TileType.house:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = -10f;
                        scoreholder.qualLifePts = 20f;
                        scoreholder.pedSafetyDesc = "No possible impact.";
                        scoreholder.floodDesc = "Breeding ground: spread pollutants, and create a breeding ground for mosquitos";
                        scoreholder.qualLifeDesc = "Continuous greenness: through water availability for plants.";
                        break;
                    case TileValues.TileType.none:
                        //skip empty tile
                        break;
                }
                break;
            case TileValues.TileType.bioswale:
                //check interactions with all types
                switch (tileTwo.type)
                {
                    case TileValues.TileType.road:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = 0f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "missing";
                        scoreholder.floodDesc = "missing";
                        scoreholder.qualLifeDesc = "missing";
                        break;
                    case TileValues.TileType.wetlands:
                        scoreholder.pedSafetyPts = -10f;
                        scoreholder.floodPts = -15f;
                        scoreholder.qualLifePts = 30f;
                        scoreholder.pedSafetyDesc = "High level maintenance: Blockage, ponding, overgrowth, frequent inspection.";
                        scoreholder.floodDesc = "Flow restrictions:Trash and debris left to accumulate in either the storm drainage system leading to restrict the flow of water causing localized flooding and possible erosion, create sediment buildup, and create aesthetic problems that create poor public perception of the site.";
                        scoreholder.qualLifeDesc = "Habitat diversity: Creating new forms of habitat diversity than those displaced by construction, but are beneficial (e.g. wildlife species and insects).";
                        break;
                    case TileValues.TileType.bioswale:
                        scoreholder.pedSafetyPts = -10f;
                        scoreholder.floodPts = -10f;
                        scoreholder.qualLifePts = 10f;
                        scoreholder.pedSafetyDesc = "Mess-littering: Collect debris and trash.";
                        scoreholder.floodDesc = "Plant choice: Require selective plants to sustain dry/wet periods. Perceived as messy because of the plants. Some people can feel uncomfortable with the flora and fauna.";
                        scoreholder.qualLifeDesc = "Aesthetic benefits: an added green/grey space in concrete/ vegetated landscapes providing a natural/urban and pleasant place.";
                        break;
                    case TileValues.TileType.house:
                        scoreholder.pedSafetyPts = 30f;
                        scoreholder.floodPts = 50f;
                        scoreholder.qualLifePts = -30f;
                        scoreholder.pedSafetyDesc = "Social benefits (health, recreational amenities: Space for people to meet, motivating people to go outside their homes to improve their physical and emotional health, as well as an opportunity for people to have green exposure in places that lack green landscapes.";
                        scoreholder.floodDesc = "Mitigation efforts: to control runoff created from development.";
                        scoreholder.qualLifeDesc = "Property value: Urban residents expect the plant on the sidewalk to be trimmed in order to maintain/increase the value of their homes.";
                        break;
                    case TileValues.TileType.none:
                        //skip empty tile
                        break;
                }
                break;
            case TileValues.TileType.house:
                //check interactions with all types
                switch(tileTwo.type)
                {
                    case TileValues.TileType.road:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = 0f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "missing";
                        scoreholder.floodDesc = "missing";
                        scoreholder.qualLifeDesc = "missing";
                        break;
                    case TileValues.TileType.wetlands:
                        scoreholder.pedSafetyPts = 0f;
                        scoreholder.floodPts = -10f;
                        scoreholder.qualLifePts = 20f;
                        scoreholder.pedSafetyDesc = "No possible impact.";
                        scoreholder.floodDesc = "Breeding ground: spread pollutants, and create a breeding ground for mosquitos";
                        scoreholder.qualLifeDesc = "Continuous greenness: through water availability for plants.";
                        break;
                    case TileValues.TileType.bioswale:
                        scoreholder.pedSafetyPts = 30f;
                        scoreholder.floodPts = 50f;
                        scoreholder.qualLifePts = -30f;
                        scoreholder.pedSafetyDesc = "Social benefits (health, recreational amenities: Space for people to meet, motivating people to go outside their homes to improve their physical and emotional health, as well as an opportunity for people to have green exposure in places that lack green landscapes.";
                        scoreholder.floodDesc = "Mitigation efforts: to control runoff created from development.";
                        scoreholder.qualLifeDesc = "Property value: Urban residents expect the plant on the sidewalk to be trimmed in order to maintain/increase the value of their homes.";
                        break;
                    case TileValues.TileType.house:
                        scoreholder.pedSafetyPts = 5f;
                        scoreholder.floodPts = -30f;
                        scoreholder.qualLifePts = -5f;
                        scoreholder.pedSafetyDesc = "Community: social equity, safe communities, shared environment, social cohesion.";
                        scoreholder.floodDesc = "Urban heat";
                        scoreholder.qualLifeDesc = "More housing, less yard";
                        break;
                    case TileValues.TileType.none:
                        //skip empty tile
                        break;
                }
                break;
            case TileValues.TileType.none:
                //skip empty tile
                break;
        }
        scoreholder.printScore();
        return scoreholder;
    }
}

