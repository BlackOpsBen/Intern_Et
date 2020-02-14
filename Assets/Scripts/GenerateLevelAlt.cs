using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelAlt : MonoBehaviour
{
    int maxNumDividers = 3;
    int numDividers = 0;

    GameObject[] floor0Nodes;
    GameObject[] floor1Nodes;
    GameObject[] floor2Nodes;
    GameObject[] floor3Nodes;
    GameObject[][] Floors;

    [SerializeField] GameObject basicFloor;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;

    GameObject previous;
    bool optionWall;

    private void Start()
    {
        floor0Nodes = GameObject.FindGameObjectsWithTag("Floor0");
        floor1Nodes = GameObject.FindGameObjectsWithTag("Floor1");
        floor2Nodes = GameObject.FindGameObjectsWithTag("Floor2");
        floor3Nodes = GameObject.FindGameObjectsWithTag("Floor3");
        Floors = new GameObject[][] { floor0Nodes, floor1Nodes, floor2Nodes, floor3Nodes };

        for (int i = 0; i < Floors.Length; i++)
        {
            previous = leftWall;
            //SetNewFloorStartCriteria();
            optionWall = false;
            GenerateFloor(i);
        }
    }

    //private void SetNewFloorStartCriteria()
    //{
    //    previous = leftWall;
    //    if (numDividers == maxNumDividers)
    //    {
    //        optionWall = false;
    //    }
    //    else
    //    {
    //        optionWall = true;
    //    }
    //}

    private void GenerateFloor(int floor)
    {
        for (int room = 0; room < Floors[floor].Length; room++)
        {
            if (optionWall)
            {
                RollForRoomOrWall(floor, room);
            }
            else
            {
                GenerateRoom(basicFloor, floor, room);
                optionWall = true;
            }
        }
    }

    private void RollForRoomOrWall(int floor, int room)
    {
        int randomRoll = UnityEngine.Random.Range(0, 2);
        if (randomRoll == 0)
        {
            GenerateRoom(basicFloor, floor, room);
            optionWall = true;
        }
        else
        {
            GenerateRoom(GetEligibleWall(room), floor, room);
            optionWall = false;
        }
    }

    private void GenerateRoom(GameObject roomTile, int floor, int room)
    {
        Instantiate(roomTile, Floors[floor][room].transform.position, Quaternion.identity);
        previous = roomTile;
    }

    private GameObject GetEligibleWall(int room)
    {
        if (room <= 1)
        {
            return leftWall;
        }
        else
        {
            return rightWall;
        }
    }
}
