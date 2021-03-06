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
        if (col.gameObject.name == "Player")
            inRadius = true;
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player")
            inRadius = false;
    }
}
