using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    int numWalls = 3;
    int[] floorWallCounts;

    GameObject[] floor0Nodes;
    GameObject[] floor1Nodes;
    GameObject[] floor2Nodes;
    GameObject[] floor3Nodes;
    GameObject[][] Floors;

    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;


    private void Start()
    {
        floor0Nodes = GameObject.FindGameObjectsWithTag("Floor0");
        floor1Nodes = GameObject.FindGameObjectsWithTag("Floor1");
        floor2Nodes = GameObject.FindGameObjectsWithTag("Floor2");
        floor3Nodes = GameObject.FindGameObjectsWithTag("Floor3");
        Floors = new GameObject[][] { floor0Nodes, floor1Nodes, floor2Nodes, floor3Nodes };

        DetermineFloorsForWalls(numWalls);

        DetermineNodesForWalls();

        for (int floor = 0; floor < Floors.Length; floor++)
        {
            GenerateFloor(floor);
        }
    }

    private void GenerateFloor(int floor)
    {
        
    }

    private void DetermineFloorsForWalls(int walls)
    {
        floorWallCounts = new int[] { 0, 0, 0, 0 };
        for (int i = 0; i < walls; i++)
        {
            int roll;
            do
            {
                roll = RollDie(4);
            } while (floorWallCounts[roll] == 2);
            floorWallCounts[roll]++;
        }
    }

    private void DetermineNodesForWalls()
    {
        
    }

    private int RollDie(int sides)
    {
        return UnityEngine.Random.Range(0, sides + 1);
    }

}


/* Start with max number of walls
 * Roll that many D4s to determine which floors they will go on.
 * For each floor
 *      if received 1 wall
 *          roll between 4 and 13 and place wall there
 *      if received 2 walls
 *          flip a coin to determine which wall rolls and is placed first
 *              if 1st wall
 *                  roll between 4 and 8 to place
 *                  then roll between placement+5 and 13
 *              else if 2nd wall
 *                  roll between 9 and 13
 *                  then roll between 4 and placement-5
 *      else if no walls received
 *          do nothing
 *  */
 