using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear_gauge : MonoBehaviour
{
    // Variables
    [SerializeField] public int fearPoints = 0;
    [SerializeField] public int maxFearPoints = 100;
    [SerializeField] public int minFearPoints = 0;
    public float fearBarLength;

    public GameObject textDisplayLose;

    Ghost ghost;

    // Start is called before the first frame update
    void Start()
    {
        textDisplayLose.SetActive(false);
        ghost = FindObjectOfType<Ghost>();
        fearBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentFear(0);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 5, 5, fearBarLength, 20), fearPoints + " / " + maxFearPoints);
    }

    public void AdjustCurrentFear(int adj)
    {
        fearPoints += adj;
        if (fearPoints < 0)
        {
            fearPoints = 0;
        }
        if (fearPoints >= 100)
        {
            fearPoints = 100;
            textDisplayLose.SetActive(true);
        }
        fearBarLength = (Screen.width / 2) * (fearPoints / (float)maxFearPoints);
    }
}
