using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variables of moving
    [SerializeField] float xValue = 0f;
    [SerializeField] float yValue = 0f;
    float zValue = 0f;
    [SerializeField] float speedCoefficient = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(xValue,yValue,zValue);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float xValue = (Input.GetAxis("Horizontal") * Time.deltaTime) * speedCoefficient;
        float yValue = (Input.GetAxis("Vertical") * Time.deltaTime) * speedCoefficient;
        transform.Translate(xValue, yValue, 0f);
    }
}
