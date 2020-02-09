using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public KeyCode playKey;

    public Button playButton;

    private void Update()
    {
        if (Input.GetKeyDown(playKey))
        {
            playButton.onClick.Invoke();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
