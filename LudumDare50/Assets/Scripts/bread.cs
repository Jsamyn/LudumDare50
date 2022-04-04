using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bread : MonoBehaviour
{
    private GameObject player;
    public bool inRadius = false;

    void Start() {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player")
            inRadius = true;
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player")
            inRadius = false;
    }
}
