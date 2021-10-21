using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject quitButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void DisplayTutorial()
    {
        tutorialText.SetActive(true);
        quitButton.SetActive(false);

    }

    public void CloseTutorial() 
    {
        tutorialText.SetActive(false);
        quitButton.SetActive(true);
    }
}
