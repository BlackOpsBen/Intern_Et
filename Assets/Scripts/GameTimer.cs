using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    float timeMeasurement = 0.1f;
    float gameTime = 0.0f;
    bool isTiming = false;
    int currentLevel;
    float[] levelTimes;
    float bestTotalTime = float.MaxValue;

    public bool isNewBest = true;
    
    // Start is called before the first frame update
    void Start()
    {
        levelTimes = new float[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < levelTimes.Length; i++)
        {
            levelTimes[i] = 0.0f;
        }
        DontDestroyOnLoad(this.gameObject); // TODO make object kill itself if one already exists.
        StartCoroutine(TrackTime());
    }

    private IEnumerator TrackTime()
    {
        while(true) // do forever
        {
            yield return new WaitForSeconds(timeMeasurement);
            if (isTiming)
            {
                gameTime += timeMeasurement;
            }
        }
    }

    public void StartTimer()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
        levelTimes[currentLevel] = gameTime;
        ResetTimer();
    }

    private void ResetTimer()
    {
        gameTime = 0.0f;
    }

    public string[] GetAllLevelTimes()
    {
        string[] allTimes = new string[levelTimes.Length];
        for (int i = 0; i < allTimes.Length; i++)
        {
            allTimes[i] = GetLevelTimeStamp(levelTimes[i]);
        }
        return allTimes;
    }

    public string GetCurrentLevelTime()
    {
        return ConvertToTimeStamp(levelTimes[currentLevel]);
    }

    public string GetTotalTime()
    {
        float totalTime = GetTotalTimeRaw();
        return ConvertToTimeStamp(totalTime);
    }

    private float GetTotalTimeRaw()
    {
        float totalTime = 0.0f;
        for (int i = 0; i < levelTimes.Length; i++)
        {
            totalTime += levelTimes[i];
        }

        return totalTime;
    }

    public string ConvertToTimeStamp(float levelTime)
    {
        string timeStamp;
        float minutes = Mathf.Floor(levelTime / 60);
        float seconds = levelTime % 60;
        if (minutes > float.Epsilon)
        {
            timeStamp = minutes.ToString("F0") + "m " + seconds.ToString("F2") + "s";
        }
        else
        {
            timeStamp = seconds.ToString("F2") + "s";
        }

        return timeStamp;
    }

    private string GetLevelTimeStamp(float levelTime)
    {
        return ConvertToTimeStamp(levelTime);
    }

    public float GetBestTime()
    {
        if (GetTotalTimeRaw() < bestTotalTime)
        {
            isNewBest = true;
            bestTotalTime = GetTotalTimeRaw();
        }
        else
        {
            isNewBest = false;
        }
        return bestTotalTime;
    }
}
