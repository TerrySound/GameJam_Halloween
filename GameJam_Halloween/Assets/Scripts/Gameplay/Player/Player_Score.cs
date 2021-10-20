using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Score : MonoBehaviour
{
    [SerializeField] int points = 0;
    [SerializeField] TextMeshProUGUI text;
    int indice = 0;
    [SerializeField] TextMeshProUGUI speedText;
    //private int i = 0;

    Mover move;

    // Start is called before the first frame update
    void Start()
    {
        move = FindObjectOfType<Mover>();
        text.text = points.ToString();
        speedText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = points.ToString();
    }

    public void ManagePoints(int a)
    {
        points += a;
        if (points >= 5 && indice <= 0)
        {
            indice += 1;
            move.speedCoefficient += 1;
            StartCoroutine(SpriteSet());
        }
        if (points >= 10 && indice <= 1)
        {
            indice += 1;
            move.speedCoefficient += 1;
            StartCoroutine(SpriteSet());
        }
        if (points >= 15 && indice <= 2)
        {
            indice += 1;
            move.speedCoefficient += 1;
            speedText.text = "Speed Increased to the Maximum !";
            StartCoroutine(SpriteSet());
        }
    }
    IEnumerator SpriteSet()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            speedText.enabled = true;
            yield return new WaitForSeconds(0.5f);
            speedText.enabled = false;
        }
    }
}