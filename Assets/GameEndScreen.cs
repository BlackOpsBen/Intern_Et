﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headerText;
    [SerializeField] Button playAgainButton;

    public KeyCode playKey;


    float cycleInterval = 2f;

    private void Awake()
    {
        playAgainButton.gameObject.SetActive(false);
        StartCoroutine(cycleText());
    }

    private void Update()
    {
        if (Input.GetKeyDown(playKey))
        {
            playAgainButton.onClick.Invoke();
        }
    }

    private IEnumerator cycleText()
    {
        headerText.text = "You win!";
        yield return new WaitForSeconds(cycleInterval);
        headerText.text = "Thank you for playing!";
        yield return new WaitForSeconds(cycleInterval);
        headerText.text = "Play again?";
        playAgainButton.gameObject.SetActive(true);
    }

    public void playAgain()
    {
        SceneManager.LoadScene(0);
    }
}
