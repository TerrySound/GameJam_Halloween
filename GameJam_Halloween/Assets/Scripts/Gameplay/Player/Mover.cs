using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variables of moving
    [SerializeField] float xValue = 4.267f;
    [SerializeField] float yValue = -13f;
    float zValue = 0f;
    [SerializeField] public float speedCoefficient = 1f;
    public Animator animator;
    public int rotationSpeed;

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
        float xValue = (Input.GetAxis("Horizontal"));
        float yValue = (Input.GetAxis("Vertical"));

        animator.SetFloat("Speed", Mathf.Abs(xValue) + Mathf.Abs(yValue));

        Vector2 movementDirection = new Vector2(xValue, yValue);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speedCoefficient * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward,movementDirection);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
