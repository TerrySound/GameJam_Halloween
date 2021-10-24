using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ColliderEndGame : MonoBehaviour
{
    public PlayableDirector EndGameCutscene;
    

    private void OnTriggerEnter(Collider other)
    {
        EndGameCutscene.Play();
    }

    private void Awake()
    {
        EndGameCutscene.stopped += EndGameCutscene_Stopped;
    }

    private void EndGameCutscene_Stopped(PlayableDirector obj)
    {
        SceneManager.LoadScene("MenuScene");
    }
}
