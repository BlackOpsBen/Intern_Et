using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headerText;
    [SerializeField] TextMeshProUGUI subText;

    public void StartOff()
    {
        gameObject.SetActive(false);
    }

    public void ActivateEndScreen(bool loseWater, bool loseCoffee)
    {
        if(!loseWater && !loseCoffee)
        {
            headerText.text = "Complete";
            subText.text = "Good job";
        }
        else if (loseWater && !loseCoffee)
        {
            headerText.text = "Failure";
            subText.text = "to stay hydrated";
        }
        else if (!loseWater && loseCoffee)
        {
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