using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Zone : MonoBehaviour
{
    Ghosts_Random random;
    Fear_gauge fear;
    PlayerFear player;

    public GameObject healZone;
    // Start is called before the first frame update
    void Start()
    {
        random = FindObjectOfType<Ghosts_Random>();
        fear = FindObjectOfType<Fear_gauge>();
        player = FindObjectOfType<PlayerFear>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.currentFear > 0)
            {
                player.currentFear -= 10;
                player.VerifyFear();
                player.StartCoroutine(player.ColorHeal());
                fear.SetFear(player.currentFear);
                random.SpawnCandyEtc(healZone, 1, 0.5f);
                Destroy(gameObject);
            }
        }
    }
}
