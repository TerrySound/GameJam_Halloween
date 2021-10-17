using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject textDisplayEnd;
    public int secondLeft = 60;
    public bool takingAway = false;


    IEnumerator TimerTake() 
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        textDisplay.GetComponent<Text>().text = "00: " + secondLeft;
        takingAway = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        textDisplayEnd.SetActive(false);
        textDisplay.GetComponent<Text>().text = "00: " + secondLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondLeft > 0) 
        {
            StartCoroutine(TimerTake());
        }

        if (takingAway == false && secondLeft <=0)
        {
            textDisplayEnd.SetActive(true);
        }
    }
}
