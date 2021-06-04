using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring
{

    // loops through the grid of tiles and calculates all interaction point values.
    // used to update the total score and the three goal bars.
    public Scoreholder GetScore(TileValues.TileType[,] gridTiles)
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
                }
                // tile is at edge- only perform calculation with block +1 j over, not +1 i
                else if (i == 4)
                {
                    scoreholder = GetInteractions(gridTiles[i, j], gridTiles[i, j + 1]);
                }
                // tile is at edge- only perform calculation with block +1 i over, not +1 j
                else if (j == 4)
                {
                    scoreholder = GetInteractions(gridTiles[i, j], gridTiles[i+1, j]);
                }
                // current tile should have a tile below and next to it 
                else
                {
                    //get flood score with block next to it (+1 j)
                    scoreholder = GetInteractions(gridTiles[i, j], gridTiles[i, j+1]);

                    // add scores from current tile interaction to total scores 
                    totalScores.floodPts += scoreholder.floodPts;
                    totalScores.pedSafetyPts += scoreholder.pedSafetyPts;
                    totalScores.qualLifePts += scoreholder.qualLifePts;

                    //get flood score with block below it (+1 i)
                    scoreholder = GetInteractions(gridTiles[i, j], gridTiles[i + 1, j]);
                }
                // add scores from current tile interaction to total scores 
                totalScores.floodPts += scoreholder.floodPts;
                totalScores.pedSafetyPts += scoreholder.pedSafetyPts;
                totalScores.qualLifePts += scoreholder.qualLifePts;
            }
        }
        return totalScores;
    }



    // Calculate scores between most recently placed blocks and up to 4 adjacent blocks surrounding it. 
    // Useful for passing text into the scorepanel.
    public List<Scoreholder> GetCurrentTileScores(TileValues.TileType[,] gridTiles, int col, int row)
    {
        List<Scoreholder> scoreList = new List<Scoreholder>();    // stores list of current tile's interactions with surrounding tiles 
        Scoreholder scoreholder = new Scoreholder();              // stores current tile interaction's score and description

        // check if tile is at boundary locations and calculate interaction scores with up to 4 adjacent tiles  
        if (col < 4)
        {
            if (gridTiles[col + 1, row] != TileValues.TileType.none)
            {
                scoreholder = GetInteractions(gridTiles[col + 1, row], gridTiles[col, row]);
                scoreList.Add(scoreholder);
            }
        }
        if (row < 4)
        {
            if (gridTiles[col, row + 1] != TileValues.TileType.none)
            {
                scoreholder = GetInteractions(gridTiles[col, row + 1], gridTiles[col, row]);
                scoreList.Add(scoreholder);
            }
        }
        if (col > 0)
        {
            if (gridTiles[col - 1, row] != TileValues.TileType.none)
            {
                scoreholder = GetInteractions(gridTiles[col - 1, row], gridTiles[col, row]);
                scoreList.Add(scoreholder);
            }
        }
        if (row > 0)
        {
            if (gridTiles[col, row - 1] != TileValues.TileType.none)
            {
                scoreholder = GetInteractions(gridTiles[col, row - 1], gridTiles[col, row]);
                scoreList.Add(scoreholder);
            }
        }

        return scoreList;
    }





    public Scoreholder GetInteractions(TileValues.TileType tileOne, TileValues.TileType tileTwo)
    {
        // Debug.Log("Interaction: " + tileOne + ", " + tileTwo);
        Scoreholder scoreholder = new Scoreholder();

        scoreholder.tileOne = tileOne;
        scoreholder.tileTwo = tileTwo;

        switch(tileOne)
        {
            case TileValues.TileType.road:
                //check interactions with all types
                switch (tileTwo)
                {
                    case TileValues.TileType.road:
                        scoreholder.pedSafetyPts = 10f;
                        scoreholder.floodPts = 5f;
                        scoreholder.qualLifePts = 20f;
                        scoreholder.pedSafetyDesc = "Access to transportation";
                        scoreholder.floodDesc = "Drainage";
                        scoreholder.qualLifeDesc = "Access and parking";
                        break;
                    case TileValues.TileType.wetlands:
                        scoreholder.pedSafetyPts = -10f;
                        scoreholder.floodPts = 20f;
                        scoreholder.qualLifePts = 20f;
                        scoreholder.pedSafetyDesc = "Alter/ disturb wildlife habitat: Impede animal, migration, and disperse nonnative pest species of plants and animals.";
                        scoreholder.floodDesc = "Flood storage: Shoreline erosion control.";
                        scoreholder.qualLifeDesc = "Economically beneficial natural products for human use: Provide opportunities for recreation, education, and research.";
                        break;
                    case TileValues.TileType.bioswale:
                        scoreholder.pedSafetyPts = -5f;
                        scoreholder.floodPts = 20f;
                        scoreholder.qualLifePts = -5f;
                        scoreholder.pedSafetyDesc = "Safety: People might injure themselves by falling into them because the plants obscured the sinkholes.";
                        scoreholder.floodDesc = "Hazard mitigation: Absorb then redirect runoff to the stormwater management system.Hence, reduces the overall flow rate.";
                        scoreholder.qualLifeDesc = "Parking: The design can make pavement wider and streets narrower and hence impact the flow of traffic and reduce the parking spaces";
                        break;
                    case TileValues.TileType.house:
                        scoreholder.pedSafetyPts = 30f;
                        scoreholder.floodPts = -20f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "Safe grounds: security, public safety (neighborhood watch program)";
                        scoreholder.floodDesc = "Flooded roads: Hinder commutes and access.";
                        scoreholder.qualLifeDesc = "Damaging effects of road construction and management: Noise, dust, traffic congestion, and vibration.";
                        break;
                    case TileValues.TileType.none:
                        //skip empty tile
                        break;
                }
                break;
            case TileValues.TileType.wetlands:
                //check interactions with all types
                switch (tileTwo)
                {
                    case TileValues.TileType.road:
                        scoreholder.pedSafetyPts = -10f;
                        scoreholder.floodPts = 20f;
                        scoreholder.qualLifePts = 20f;
                        scoreholder.pedSafetyDesc = "Alter/ disturb wildlife habitat: Impede animal, migration, and disperse nonnative pest species of plants and animals.";
                        scoreholder.floodDesc = "Flood storage: Shoreline erosion control.";
                        scoreholder.qualLifeDesc = "Economically beneficial natural products for human use: Provide opportunities for recreation, education, and research.";
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
                switch (tileTwo)
                {
                    case TileValues.TileType.road:
                        scoreholder.pedSafetyPts = -5f;
                        scoreholder.floodPts = 20f;
                        scoreholder.qualLifePts = -5f;
                        scoreholder.pedSafetyDesc = "Safety: People might injure themselves by falling into them because the plants obscured the sinkholes.";
                        scoreholder.floodDesc = "Hazard mitigation: Absorb then redirect runoff to the stormwater management system.Hence, reduces the overall flow rate.";
                        scoreholder.qualLifeDesc = "Parking: The design can make pavement wider and streets narrower and hence impact the flow of traffic and reduce the parking spaces";
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
                switch(tileTwo)
                {
                    case TileValues.TileType.road:
                        scoreholder.pedSafetyPts = 30f;
                        scoreholder.floodPts = -20f;
                        scoreholder.qualLifePts = 0f;
                        scoreholder.pedSafetyDesc = "Safe grounds: security, public safety (neighborhood watch program)";
                        scoreholder.floodDesc = "Flooded roads: Hinder commutes and access.";
                        scoreholder.qualLifeDesc = "Damaging effects of road construction and management: Noise, dust, traffic congestion, and vibration.";
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
        if ((tileOne != TileValues.TileType.none) && (tileTwo != TileValues.TileType.none)) // only log score between two actual tiles 
        {
/*            Debug.Log("Interaction: " + tileOne + ", " + tileTwo);
            scoreholder.printScore();*/
        }
        return scoreholder;
    }
}

