using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts_Random : MonoBehaviour
{
    [Range(0, 50)] [SerializeField] private int numberToSpawnGhosts;
    [Range(0, 50)] [SerializeField] private int numberToSpawnGhostsChase;
    [Range(0, 50)] [SerializeField] private int numberToSpawnCandy;
    [SerializeField] private List<GameObject> spawnPool;
    [SerializeField] private GameObject quad;

    public GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        DestroyObjects();
        SpawnObjectsAtStart();
    }

    void SpawnObjectsAtStart()
    {
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawnGhosts; i++)
        {
            toSpawn = spawnPool[0];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

            pos = new Vector3(screenX, screenY,-0.2f);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

        }
        for (int i = 0; i < numberToSpawnCandy; i++)
        {
            toSpawn = spawnPool[1];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

            pos = new Vector3(screenX, screenY, 0.25f);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

        }

        for (int i = 0; i < numberToSpawnGhostsChase; i++)
        {
            toSpawn = spawnPool[2];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

            pos = new Vector3(screenX, screenY, 0.25f);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

        }
    }
    private void DestroyObjects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }

    public void SpawnCandy(GameObject toSpawn, int numberToSpawn)
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

            pos = new Vector3(screenX, screenY, -0.2f);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

        }
    }
    public void SpawnGhost(GameObject toSpawn, int numberToSpawn)
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            screenX = SpawnPoint.transform.position.x;
            screenY = SpawnPoint.transform.position.y;

            pos = new Vector3(screenX, screenY, -0.2f);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

        }
    }
}
