using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class GameFlow : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject quitButton;
    public GameObject ui;
    public PlayableDirector startCutscene;

    private void Awake()
    {
        startCutscene.stopped += StartCutscene_Stopped;
    }

    private void StartCutscene_Stopped(PlayableDirector obj) 
    {
        PlayGame();
    }

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
        AkSoundEngine.PostEvent("UI_Play", gameObject);

    }

    public void CloseTutorial() 
    {
        tutorialText.SetActive(false);
        quitButton.SetActive(true);
        AkSoundEngine.PostEvent("UI_Back", gameObject);
    }

    public void PlayStartCutscene()
    {
        tutorialText.SetActive(false);
        ui.SetActive(false);
        startCutscene.Play();
    }

    public void SFXStartGame()
    {
        AkSoundEngine.PostEvent("UI_StartGame", gameObject);
    }

}
