using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Score : MonoBehaviour
{
    [SerializeField] int points = 0;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = points.ToString();
    }

    public void AddPoints(int a)
    {
        points += a;
    }
}