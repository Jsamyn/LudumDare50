using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /* Public Variables */
    /// The acceleration of the character movement
    public float acceleration;

    /// The max speed a character can move
    public float maxSpeed;

    /* Private Variables */
    private KeyCode[] inputKeys;
    private Vector3[] directionsForKeys;

    // Start is called before the first frame update
    void Start()
    {
        inputKeys = new KeyCode[] {KeyCode.W, KeyCode.A, }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
