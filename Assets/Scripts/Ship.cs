using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float colliderRadius;
    
    //CircleCollider2D collider = GetComponent<CircleCollider2D>();
    private Vector2 thrustDirection = new Vector2(1, 0);
    [SerializeField] private float thrustForce = 10f;
    [SerializeField] private float RotateDegreesPerSecond = 100f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        colliderRadius = collider.radius;
        //Vector2D thrustDirection = new Vector2D()
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input from the Rotate axis
        float rotationInput = Input.GetAxis("Rotate");

        // Calculate rotation amount based on input and rotation speed
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        if (rotationInput < 0)
        {
            rotationAmount *= -1;
        }

        // Apply rotation around the ship's vertical axis (Z-axis in Unity's 3D space)
        transform.Rotate(Vector3.forward, rotationAmount);
    }


    void FixedUpdate()
    {
        // This method is called at fixed intervals and is suitable for applying physics actions.
        // It's used for actions like applying thrust, which involve physics calculations.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If space key is pressed, apply force in the direction of thrustDirection
            // Scaled by the defined thrustForce and using ForceMode2D.Force
            if (rb2d != null)
            {
                // Apply thrust using the stored Rigidbody2D component and thrustDirection
                rb2d.AddForce(thrustDirection * thrustForce, ForceMode2D.Force);
            }
            else
            {
                Debug.LogError("Rigidbody2D component is not attached to the Ship!");
            }
        }
    }

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

        // Apply new position
        transform.position = newPosition;
    }
}

