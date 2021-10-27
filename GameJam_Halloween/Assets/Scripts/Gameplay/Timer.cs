using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject textDisplayEnd;
    public GameObject ColliderEnd;
    public int secondLeft = 120;
    public bool takingAway = false;
    int indice = 0;

    Ghosts_Random random;
    public GameObject ghost;
    public GameObject ghostChase;

    public PlayableDirector winCutscene;
    public bool bWin;
    public GameObject SpotEmitter;

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
            AkSoundEngine.PostEvent("Arrival", SpotEmitter);
        }
        if (indice == 30)
        {
            random.SpawnGhost(ghost,7);
            AkSoundEngine.PostEvent("Arrival", SpotEmitter);
        }
        if (indice == 60)
        {
            random.SpawnGhost(ghostChase, 1);
            random.SpawnGhost(ghost, 7);
            AkSoundEngine.PostEvent("Arrival", SpotEmitter);
        }
        if (indice == 90)
        {
            random.SpawnGhost(ghostChase, 1);
            random.SpawnGhost(ghost, 7);
            AkSoundEngine.PostEvent("Arrival", SpotEmitter);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        random = FindObjectOfType<Ghosts_Random>();
        textDisplayEnd.SetActive(false);
        ColliderEnd.SetActive(false);
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
            ColliderEnd.SetActive(true);

            Object[] allObjects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject obj in allObjects)
            {
                if (obj.transform.name == "Ghost(Clone)")
                {
                    Destroy(obj);
                }

                if (obj.transform.name == "Ghost_Chase(Clone)")
                {
                    Destroy(obj);
                }
            }

            if (bWin == false)
            {
                winCutscene.Play();
                bWin = true;
            }
        }
    }
}
