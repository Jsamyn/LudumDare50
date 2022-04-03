using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public Room left = null;
    public Room right = null;
    public Room up = null;
    public Room down = null;
    public int roomCount = 1;
    public Vector3 leftDoor = new Vector3(-6, 0, 0);
    public Vector3 rigthDoor = new Vector3(9, 0, 0);
    public Vector3 upDoor = new Vector3(0, 3, 0);
    public Vector3 downDoor = new Vector3(0, -6, 0);
    public GameObject player;


    // Start is called before the first frame update
    void Start() {
        if (SceneManager.GetActiveScene().name == "Tree") return;

    }

    // Update is called once per frame
    void Update() {
        if (player.transform.position.x < leftDoor.x) {
            if (left == null) addRoom('l');
        } else if (player.transform.position.x > rigthDoor.x) {
            if (right == null) addRoom('r');
        } //else if (/*Player is on the up door*/) {
        //     up = new Room();
        // } else if (/*Player is on the down door*/) {
        //     down = new Room();
        // }
    }

    void addRoom(char c) {
        switch(c) {
            case 'l': {
                if (!SceneManager.GetSceneByName("scene_left_" + roomCount).IsValid()) {
                    Scene newScene = SceneManager.CreateScene("scene_left_" + roomCount);
                    //roomCount++;
                }
                break;
            }
            case 'r': {

                break;
            }
        }
    }
}
