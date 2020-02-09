using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headerText;
    [SerializeField] TextMeshProUGUI subText;
    [SerializeField] AudioSource loseJingle;
    [SerializeField] AudioSource winJingle;
    [SerializeField] GameTimer gameTimer;
    GameObject musicPlayer;

    private void Awake()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        musicPlayer = GameObject.Find("Music");
    }

    public void StartOff()
    {
        gameObject.SetActive(false);
    }

    public void ActivateEndScreen(bool loseWater, bool loseCoffee)
    {
        gameTimer.StopTimer();

        musicPlayer.GetComponent<AudioSource>().Stop();
        if(!loseWater && !loseCoffee)
        {
            loseJingle.playOnAwake = false;
            headerText.text = "Complete";
            subText.text = "Time: " + gameTimer.GetCurrentLevelTime();
        }
        else if (loseWater && !loseCoffee)
        {
            winJingle.playOnAwake = false;
            headerText.text = "Failure";
            subText.text = "to stay hydrated";
        }
        else if (!loseWater && loseCoffee)
        {
            winJingle.playOnAwake = false;
            headerText.text = "Failure";
            subText.text = "to provide coffee";
        }
        gameObject.SetActive(true);
    }

    public void SwitchToReadyScreen(string readyText)
    {
        headerText.text = "Ready?";
        subText.text = readyText;
    }
}