using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PlayerFear : MonoBehaviour
{
    public int maxFear = 100;
    public int minFear = 0;
    public int currentFear;
    public int iterationHitColor = 2;
    public int iterationHealColor = 2;

    public Fear_gauge fearBar;
    public GameObject textDisplayLose;
    public GameObject deathbButton;
    SpriteRenderer sprite;
    public PlayableDirector loseCutscene;
    public Mover moveScript;


    private void Awake()
    {
       loseCutscene.stopped += loseCutscene_Stopped;
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        currentFear = minFear;
        fearBar.SetMinFear(minFear);
        textDisplayLose.SetActive(false);
        deathbButton.SetActive(false);
        //Time.timeScale = 1;
        moveScript = FindObjectOfType<Mover>();
        VerifyFear();
    }

    public void TakeFear(int damage)
    {
        StartCoroutine(ColorHit());
        currentFear += damage;
        VerifyFear();
        fearBar.SetFear(currentFear);
        AkSoundEngine.PostEvent("Hit", gameObject);
    }

    public void VerifyFear()
    {
        if (currentFear < 0)
        {
            currentFear = 0;
        }
        if (currentFear >= 100)
        {
            currentFear = 100;
            loseCutscene.Play();
            AkSoundEngine.PostEvent("Death", gameObject);
            // Time.timeScale = 0;
            moveScript.enabled = false;
        }
    }
    IEnumerator ColorHit()
    {
        for (int i = 0; i < iterationHitColor; i++)
        {
            yield return new WaitForSeconds(0.3f);
            sprite.color = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(0.3f);
            sprite.color = new Color32(255, 255, 255, 255);
        }
    }
    public IEnumerator ColorHeal()
    {
        for (int i = 0; i < iterationHealColor; i++)
        {
            yield return new WaitForSeconds(0.3f);
            sprite.color = new Color32(0, 255, 0, 255);
            yield return new WaitForSeconds(0.3f);
            sprite.color = new Color32(255, 255, 255, 255);
        }
    }

    private void loseCutscene_Stopped(PlayableDirector obj) 
    {
        SceneManager.LoadScene("MainScene");
    }
}
