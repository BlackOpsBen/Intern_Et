using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PC[] pcsToFix;
    [SerializeField] CoffeeLevel[] employeesToRefill;
    [SerializeField] Hydration playerHydration;
    [SerializeField] TextMeshProUGUI pcCounter;
    [SerializeField] RectTransform waterMeter;
    [SerializeField] GameObject endScreen;
    [SerializeField] float waterFillMaxSize = 200f;
    float waterFillCurrentSize;
    int pcsRemaining;

    int nextScene;
    int currentScene;

    bool isEnded = false;

    // Start is called before the first frame update
    void Awake()
    {
        endScreen = FindObjectOfType<EndScreen>();

        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        currentScene = SceneManager.GetActiveScene().buildIndex;

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
            UpdateWaterMeter();
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
        SceneManager.LoadScene(nextScene);
    }

    void LoseGameWater()
    {
        SceneManager.LoadScene(currentScene);
    }

    void LoseGameCoffee()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void UpdatePCCounter()
    {
        pcsRemaining--;
        pcCounter.text = pcsRemaining.ToString();
    }

    private void UpdateWaterMeter()
    {
        waterFillCurrentSize = playerHydration.hydrationLevel * waterFillMaxSize / playerHydration.GetMaxHydration();
        waterMeter.localScale = new Vector3(waterFillCurrentSize, 1, 1);
    }
}
