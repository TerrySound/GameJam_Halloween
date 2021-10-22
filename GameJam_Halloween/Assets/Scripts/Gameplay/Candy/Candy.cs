using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [Range(0, 5)] [SerializeField] int speedPoints = 1;

    Player_Score player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.currentSpeedPoints < 5)
            {
                player.TakeSpeedPoints(speedPoints);
                Destroy(gameObject);
            }
        }
    }
}
