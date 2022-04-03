using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /* Public Properties */
    /// <summary>
    /// Speed of the player object
    /// </summary>
    public float Speed = 0;


    /* Private Properties */
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float adjustedspeed = Speed / 100;
        Vector3 movement = new Vector3(movementX, movementY, 0);
        transform.Translate(movement * Speed);
    }

    // Called when one of the buttons used to move the character is pressed
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
