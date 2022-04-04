using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    private GameObject player;

    void Start() {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == player.name) {
            player.GetComponent<PlayerController>().hasWater = true;
            Destroy(gameObject);
        }
    }
}
