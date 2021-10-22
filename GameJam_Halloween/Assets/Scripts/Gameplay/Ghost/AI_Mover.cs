using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Mover : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    private float screenX, screenY;
    private Vector2 target;
    public bool chasePlayer;
    private GameObject playerTransform;

    //public Transform moveSpot;
    //public GameObject quad;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        target = new Vector2(Random.Range(-10, 18.4f), Random.Range(-11.95f, 9f));
        //AdjustScreen();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (chasePlayer == true)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.transform.position, speed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            if (waitTime <= 0)
            {
                target = new Vector2(Random.Range(-10f, 18.4f), Random.Range(-11.95f, 9f));
            }
        }

        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}              