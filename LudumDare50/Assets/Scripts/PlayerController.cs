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
    public GameObject tree;
    public GameObject gameManager;
    public bool hasWater = false;
    public Animator animator;

    /* Private Properties */
    private Rigidbody2D _rb;
    private float _movementX;
    private float _movementY;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float adjustedspeed = Speed / 100;
        Vector3 movement = new Vector3(_movementX, _movementY, 0);
        transform.Translate(movement * Speed);
    }

    // Called when one of the buttons used to move the character is pressed
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        _movementX = movementVector.x;
        _movementY = movementVector.y;
        animator.SetFloat("x", _movementX);
        animator.SetFloat("y", _movementY);
    }

    private void OnInteract(InputValue input) {
        if (tree.GetComponent<TreeOfLife>().inRadius && hasWater) {
            gameManager.GetComponent<GameManager>().addWater();
            hasWater = false;
        }
    }
}
