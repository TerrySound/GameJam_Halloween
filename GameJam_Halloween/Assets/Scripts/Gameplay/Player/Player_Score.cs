using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Score : MonoBehaviour
{
    [SerializeField] int points = 0;
    public int maxSpeedPoints = 5;
    public int minSpeedPoints = 0;
    public int currentSpeedPoints = 0;

    public Speed_Bar speedbar;
    public GameObject space;
    Mover move;
    public Animator characterAnimator;
    public float animationSpeedValue;
    private bool bSpeedActive;

    // Start is called before the first frame update
    void Start()
    {
        move = FindObjectOfType<Mover>();
        space.SetActive(false);
        currentSpeedPoints = minSpeedPoints;
        VerifySpeed();
        speedbar.SetMinSpeedScore(minSpeedPoints);
    }
    private void Update()
    {
        if (currentSpeedPoints == 5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (bSpeedActive)
                {
                    SpeedIncrease();
                }
            }
        }

        if (currentSpeedPoints == 0)
        {
            characterAnimator.speed = 1;
        }
    }
    public void SpeedIncrease()
    {
        AkSoundEngine.PostEvent("Speed", gameObject);
        space.SetActive(false);
        speedbar.SetSpeedScore(0);
        characterAnimator.speed = animationSpeedValue;
        StartCoroutine(SpeedTime());
        bSpeedActive = false;
    }

    public void TakeSpeedPoints(int speed)
    {
        currentSpeedPoints += speed;
        VerifySpeed();
        speedbar.SetSpeedScore(currentSpeedPoints);
    }

    public void VerifySpeed()
    {
        if (currentSpeedPoints < 0)
        {
            currentSpeedPoints = 0;
        }
        if (currentSpeedPoints >= 5)
        {
            currentSpeedPoints = 5;
            space.SetActive(true);
            bSpeedActive = true;
        }
    }

    IEnumerator SpeedTime()
    {
        move.speedCoefficient += 2;
        yield return new WaitForSeconds(5f);
        move.speedCoefficient -= 2;
        currentSpeedPoints = 0;
    }
}