using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 thrustDirection = new Vector2(1, 0);
    [SerializeField] private float thrustForce = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Vector2D thrustDirection = new Vector2D()
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
