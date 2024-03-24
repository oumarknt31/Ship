// Oumar Kante
// CSC 350H
// Dr Hao Tang
// Home Assignment 7 (22 March 2024)
// Spring 2024

// Implementation of Ship game according to its thurst.

using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float thrustForce = 10f; // Serialized field for thrust force
    [SerializeField] private float rotateDegreesPerSecond = 180f; // Serialized field for rotation speed
    //[SerializeField] private float speed = 0.025f; // Speed of the ship

    private Rigidbody2D rb2d;
    private float colliderRadius;
    private Vector2 thrustDirection;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Retrieve and store the radius from the CircleCollider2D component
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            colliderRadius = collider.radius;
        }
        else
        {
            Debug.LogError("CircleCollider2D component is not attached to the Ship!");
        }
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (rb2d != null)
            {
                rb2d.AddForce(thrustDirection * thrustForce , ForceMode2D.Force);
            }
            else
            {
                Debug.LogError("Rigidbody2D component is not attached to the Ship!");
            } // Apply thrust in the ship's current forward direction
        }
    }

    void Update()
    {
        // Process rotation input
        //float rotationInput = Input.GetAxis("Horizontal");
        float rotationInput = Input.GetAxis("rotate");
        if (rotationInput != 0)
        {
            //Debug.Log("The rotate Input is working fine");
            // Calculate rotation amount and apply rotation
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;

            // If the Rotate input axis is negative, invert the rotation amount
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // Calculate dynamic thrust direction based on ship's rotation
            float rotationRadians = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(rotationRadians);
            thrustDirection.y = Mathf.Sin(rotationRadians);
        }

        
        
    }

    // Screen wrapping logic
    void OnBecameInvisible()
    {
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = currentPosition;

        // Check exit direction and adjust ship's position accordingly
        if (currentPosition.x < ScreenUtils.ScreenLeft - colliderRadius)
        {
            newPosition.x = ScreenUtils.ScreenRight + colliderRadius;
        }
        else if (currentPosition.x > ScreenUtils.ScreenRight + colliderRadius)
        {
            newPosition.x = ScreenUtils.ScreenLeft - colliderRadius;
        }

        if (currentPosition.y < ScreenUtils.ScreenBottom - colliderRadius)
        {
            newPosition.y = ScreenUtils.ScreenTop + colliderRadius;
        }
        else if (currentPosition.y > ScreenUtils.ScreenTop + colliderRadius)
        {
            newPosition.y = ScreenUtils.ScreenBottom - colliderRadius;
        }

        // New position
        transform.position = newPosition;

    }
}