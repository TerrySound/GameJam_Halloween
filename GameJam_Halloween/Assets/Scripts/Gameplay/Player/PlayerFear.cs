using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFear : MonoBehaviour
{
    public int maxFear = 100;
    public int minFear = 0;
    public int currentFear;
    public int iterationHitColor = 2;

    public Fear_gauge fearBar;
    public GameObject textDisplayLose;
    public GameObject deathbButton;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        currentFear = minFear;
        fearBar.SetMinFear(minFear);
        textDisplayLose.SetActive(false);
        deathbButton.SetActive(false);
        Time.timeScale = 1;
        VerifyFear();
    }

    public void TakeFear(int damage)
    {
        StartCoroutine(ColorHit());
        currentFear += damage;
        VerifyFear();
        fearBar.SetFear(currentFear);
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
            textDisplayLose.SetActive(true);
            deathbButton.SetActive(true);
            Time.timeScale = 0;
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
}
