using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    GameObject[] floor0Nodes;
    GameObject[] floor1Nodes;
    GameObject[] floor2Nodes;
    GameObject[] floor3Nodes;
    GameObject[][] Floors;

    [SerializeField] GameObject basicFloor;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;

    GameObject previous;
    bool optionLeft;
    bool optionBasicFloor;
    bool optionRight;
    bool optionWall;

    private void Start()
    {
        floor0Nodes = GameObject.FindGameObjectsWithTag("Floor0");
        floor1Nodes = GameObject.FindGameObjectsWithTag("Floor1");
        floor2Nodes = GameObject.FindGameObjectsWithTag("Floor2");
        floor3Nodes = GameObject.FindGameObjectsWithTag("Floor3");
        Floors = new GameObject[][] { floor0Nodes, floor1Nodes, floor2Nodes, floor3Nodes };

        // For each floor, generate a floor
        for (int i = 0; i < Floors.Length; i++)
        {
            SetNewFloorStartingCriteria();
            GenerateFloor(i);
        }
    }

    private void SetNewFloorStartingCriteria()
    {
        previous = leftWall;
        optionLeft = false;
        optionBasicFloor = true;
        optionRight = true;
        optionWall = true;
    }

    private void GenerateFloor(int floor)
    {
        // For each room/node in the given floor, determine what tile to use, then generate it.
        for (int room = 0; room < Floors[floor].Length; room++)
        {
            if (room == 2 && previous == rightWall)
            {
                optionLeft = true;
                optionBasicFloor = false;
                optionRight = false;
                optionWall = true;
                ChooseWall(floor, room);
            }
            else if (room == 2 && (previous == basicFloor || previous == leftWall))
            {
                RollForRoomOrWall(floor, room);
            }
            else if (room == 3 && (previous == basicFloor || previous == leftWall))
            {
                ChooseBasicFloor(floor, room);
            }
            else if (optionWall && optionBasicFloor)
            {
                RollForRoomOrWall(floor, room);
            }
            else if (optionWall && !optionBasicFloor)
            {
                ChooseWall(floor, room);
            }
            else
            {
                ChooseBasicFloor(floor, room);
            }
        }
    }

    private void RollForRoomOrWall(int floor, int room)
    {
        int randomRoll = UnityEngine.Random.Range(0, 2);
        if (randomRoll == 0)
        {
            ChooseBasicFloor(floor, room);
        }
        else
        {
            ChooseWall(floor, room);
        }
    }

    private void ChooseWall(int floor, int room)
    {
        // Choose Wall
        GenerateNode(GetEligibleWall(), floor, room);
    }

    private void ChooseBasicFloor(int floor, int room)
    {
        // Choose Basic Floor
        GenerateNode(basicFloor, floor, room);
        optionLeft = false;
        optionBasicFloor = true;
        optionRight = true;
        optionWall = true;
    }

    private void GenerateNode(GameObject roomTile, int floor, int room)
    {
        Instantiate(roomTile, Floors[floor][room].transform.position, Quaternion.identity);
        previous = roomTile;
    }


    private GameObject GetEligibleWall()
    {
        if (optionLeft)
        {
            optionLeft = false;
            optionBasicFloor = true;
            optionRight = true;
            optionWall = true;
            return leftWall;
        }
        else
        {
            optionLeft = true;
            optionBasicFloor = false;
            optionRight = false;
            optionWall = true;
            return rightWall;
        }
    }



/* Current scene index determines difficulty
*
* Difficulty determines number of:
*  - Bosses
*  - Computers
*  - Elevators (1 elevator touching all 4 floors, vs 3 elevators)
*  - Doors (new: They block coffee but not movement. (maybe slow you down just a split second.))
*  - Split floors
*
* Rules:
*  - Always 1 water cooler
*  - Always a way to every floor
*  - Always 4 floors
*  - Player always starts bottom left
*  - Number of PCs 2-10 (never decreases)
*  - Number of Bosses 1-8
*  - Number of Doors 0-4, max 1 per floor
*
* Start:
* Determine number of items based on difficulty
*
*
* Building floors:
* 1st (Left) is ALWAYS left wall.
* 2nd has chance of being a floor or a right wall. (Odds of right wall depends on difficulty modifier)
*      If 2nd is Right Wall
*          3rd MUST be a left wall.
*              Since 3rd is a left wall
*                  4th has a chance of being floor or right wall.
*                      If 4th is a right wall
*                          5th MUST be a left wall
*                      Else If 4th is a floor
*                          5th MUST be a floor
*      Else If 2nd is a floor
*          3rd may be a floor or right wall
*              If 3rd is a floor
*                  4th may be a floor or a right wall
*                      If 4th is a floor
*                          5th MUST be a floor
*                      Else If 4th is a right wall
*                          5th MUST be a left wall
*              Else If 3rd is a right wall
*                  4th MUST be a left wall
*                      Since 4th is a left wall
*                          5th MUST be a floor
* 6th (right) is ALWAYS a right wall
*
* 
*/
}
