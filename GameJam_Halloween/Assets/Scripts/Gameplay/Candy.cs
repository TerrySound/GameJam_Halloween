using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] int scorePoints = 1;

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
            player.AddPoints(scorePoints);
            Destroy(gameObject);
        }
    }
}
