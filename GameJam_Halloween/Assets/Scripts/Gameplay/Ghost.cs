using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Variables
    [SerializeField] public int fearPointsInflict = 10;

    Fear_gauge fear;

    // Start is called before the first frame update
    void Start()
    {
        fear = FindObjectOfType<Fear_gauge>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fear.AdjustCurrentFear(fearPointsInflict);
        }
    }
}
