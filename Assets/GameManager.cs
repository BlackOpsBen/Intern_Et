using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PC[] pcsToFix;
    bool isWon = false;

    // Start is called before the first frame update
    void Start()
    {
        pcsToFix = FindObjectsOfType<PC>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckIfWon())
        {
            WinGame();
        }
    }

    bool CheckIfWon()
    {
        for (int i = 0; i < pcsToFix.Length; i++)
        {
            if (!pcsToFix[i].isFixed)
            {
                return false;
            }
        }
        return true;
    }

    void WinGame()
    {
        print("YOU WIN!");
    }
}
