using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Variables
    [Range(0, 100)] [SerializeField] public int fearPointsInflict = 10;

    public PlayerFear player;
    public AI_Mover ai;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerFear>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeFear(fearPointsInflict);
        }
    }
}
