using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    private float screenX, screenY;

    public Transform moveSpot;
    public GameObject quad;
    

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        AdjustScreen();
    }

    // Update is called once per frame
    void Update()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position)<0.2f)
        {
            if(waitTime<=0)
            {
                moveSpot.position = new Vector2(Random.Range(c.bounds.min.x, c.bounds.max.x), Random.Range(c.bounds.min.y, c.bounds.max.y));
            }

            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        
    }

    void AdjustScreen()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

        moveSpot.position = new Vector2(screenX, screenY);
    }
}
