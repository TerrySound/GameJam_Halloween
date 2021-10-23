using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject textDisplayEnd;
    public int secondLeft = 120;
    public bool takingAway = false;
    int indice = 0;

    Ghosts_Random random;
    public GameObject ghost;
    public GameObject ghostChase;

    IEnumerator TimerTake() 
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        textDisplay.GetComponent<Text>().text = secondLeft.ToString();
        takingAway = false;
        indice += 1;

        if (indice == 15)
        {
            random.SpawnGhost(ghostChase, 1);
        }
        if (indice == 30)
        {
            random.SpawnGhost(ghost,10);
        }
        if (indice == 60)
        {
            random.SpawnGhost(ghostChase, 1);
            random.SpawnGhost(ghost, 10);
        }
        if (indice == 90)
        {
            random.SpawnGhost(ghostChase, 1);
            random.SpawnGhost(ghost, 10);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        random = FindObjectOfType<Ghosts_Random>();
        textDisplayEnd.SetActive(false);
        textDisplay.GetComponent<Text>().text = secondLeft.ToString();
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
