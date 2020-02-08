using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] PC[] pcsToFix;
    [SerializeField] CoffeeLevel[] employeesToRefill;
    [SerializeField] Hydration playerHydration;
    [SerializeField] TextMeshProUGUI pcCounter;
    int pcsRemaining;
    bool isEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        pcsToFix = FindObjectsOfType<PC>();
        pcsRemaining = pcsToFix.Length;

        pcCounter.text = pcsRemaining.ToString();

        employeesToRefill = FindObjectsOfType<CoffeeLevel>();
        playerHydration = FindObjectOfType<Hydration>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnded)
        {
            if (CheckIfWon())
            {
                WinGame();
            }

            else if (CheckIfLostDueToWater())
            {
                LoseGameWater();
            }

            else if (CheckIfLostDueToCoffee())
            {
                LoseGameCoffee();
            }
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
        isEnded = true;
        return true;
    }

    bool CheckIfLostDueToWater()
    {
        if(!playerHydration.isHydrated)
        {
            isEnded = true;
            return true;
        }
        return false;
    }

    bool CheckIfLostDueToCoffee()
    {
        for (int i = 0; i < employeesToRefill.Length; i++)
        {
            if (employeesToRefill[i].isDecaffeinated)
            {
                isEnded = true;
                return true;
            }
        }
        return false;
    }

    void WinGame()
    {
        print("YOU WIN!"); // TODO remove
    }

    void LoseGameWater()
    {
        print("YOU LOSE due to water! Better luck next time."); // TODO remove
    }

    void LoseGameCoffee()
    {
        print("YOU LOSE due to coffee! Better luck next time."); // TODO remove
    }

    public void UpdatePCCounter()
    {
        pcsRemaining--;
        pcCounter.text = pcsRemaining.ToString();
    }
}
