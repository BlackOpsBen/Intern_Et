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
    [SerializeField] TextMeshProUGUI bestTime;
    [SerializeField] TextMeshProUGUI totalTime;
    [SerializeField] TextMeshProUGUI stageTimes;
    [SerializeField] TextMeshProUGUI tries;
    [SerializeField] TextMeshProUGUI cups;
    [SerializeField] TextMeshProUGUI refills;
    [SerializeField] GameTimer timer;
    [SerializeField] GameCounter counter;

    string[] levelTimes;

    public KeyCode playKey;


    float cycleInterval = 2f;

    private void Awake()
    {
        counter = FindObjectOfType<GameCounter>();
        timer = FindObjectOfType<GameTimer>();
        levelTimes = timer.GetAllLevelTimes();
        PopulateBestTime();
        playAgainButton.gameObject.SetActive(false);
        StartCoroutine(cycleText());
    }

    private void PopulateBestTime()
    {
        if (timer.isNewBest)
        {
            bestTime.text = "*NEW* Best: " + timer.ConvertToTimeStamp(timer.GetBestTime());
            bestTime.color = Color.magenta;
        }
        else
        {
            bestTime.text = "Best: " + timer.ConvertToTimeStamp(timer.GetBestTime());
        }
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
        
        PopulateStats();

        yield return new WaitForSeconds(cycleInterval);
        headerText.text = "Thank you for playing!";
        yield return new WaitForSeconds(cycleInterval);
        headerText.text = "Play again?";
        playAgainButton.gameObject.SetActive(true);
    }

    private void PopulateStats()
    {
        totalTime.text = "Total time: " + timer.GetTotalTime();
        for (int i = 1; i < levelTimes.Length - 1; i++) // TODO make dynamically exclude menu and end screen scenes (why int = 1 and length-1)
        {
            stageTimes.text = stageTimes.text + "\n" + "Stage " + i + ": " + levelTimes[i];
        }
        if (counter.GetTries() == 1)
        {
            tries.text = counter.GetTries().ToString() + " try";
        }
        else
        {
            tries.text = counter.GetTries().ToString() + " tries";
        }
        cups.text = counter.GetCoffees().ToString() + " cups given";
        refills.text = counter.GetRefills().ToString() + " refills";
    }

    public void playAgain()
    {
        SceneManager.LoadScene(0);
    }
}
