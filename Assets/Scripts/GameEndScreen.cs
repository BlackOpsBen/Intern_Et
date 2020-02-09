using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headerText;
    [SerializeField] Button playAgainButton;
    [SerializeField] TextMeshProUGUI totalTime;
    [SerializeField] TextMeshProUGUI stageTimes;
    [SerializeField] TextMeshProUGUI tries;
    [SerializeField] TextMeshProUGUI cups;
    [SerializeField] TextMeshProUGUI refills;
    [SerializeField] GameTimer timer;

    string[] levelTimes;

    public KeyCode playKey;


    float cycleInterval = 2f;

    private void Awake()
    {
        timer = FindObjectOfType<GameTimer>();
        levelTimes = timer.GetAllLevelTimes();
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
        totalTime.text = timer.GetTotalTime();
        for (int i = 1; i < levelTimes.Length-1; i++) // TODO make dynamically exclude menu and end screen scenes (why int = 1 and length-1)
        {
            stageTimes.text = stageTimes.text + "\n" + "Stage " + i + ": " + levelTimes[i];
        }
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
