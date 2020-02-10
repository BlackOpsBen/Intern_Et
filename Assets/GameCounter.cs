using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCounter : MonoBehaviour
{
    int numTries = 1;
    int numCoffees = 0;
    int numRefills = 0;

    public void IncreaseTries()
    {
        numTries++;
    }

    public void IncreaseCoffees()
    {
        numCoffees++;
    }

    public void IncreaseRefills()
    {
        numRefills++;
    }

    public int GetTries()
    {
        return numTries;
    }

    public int GetCoffees()
    {
        return numCoffees;
    }

    public int GetRefills()
    {
        return numRefills;
    }
}
