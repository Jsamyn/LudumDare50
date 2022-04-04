using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOfLife : MonoBehaviour
{
    /* Public Properties */
    public float ScaleRate;
    public bool inRadius = false;

    /* Private Properties */
    private float _health;
    
    void OnTriggerEnter2D(Collider2D col) {
        inRadius = true;
    }

    void OnTriggerExit2D(Collider2D col) {
        inRadius = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

    }
}
