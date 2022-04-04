using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public int roomCount;

    public GameObject left = null;
    public GameObject right = null;
    public GameObject up = null;
    public GameObject down = null;
    public Vector3 leftDoor = new Vector3(-6, 0, 0);
    public Vector3 rigthDoor = new Vector3(9, 0, 0);
    public Vector3 upDoor = new Vector3(0, 3, 0);
    public Vector3 downDoor = new Vector3(0, -6, 0);
    public GameObject player;

    public GameObject currentGrid;
    public GameObject grid1;

    // Start is called before the first frame update
    void Start() {
        currentGrid = gameObject;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if (player.transform.position.x < leftDoor.x) {
            if (left == null) addRoom('l');
            else {
                currentGrid = left;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().right.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = new Vector3(8.5f, -1.5f, 0);
            }
        } else if (player.transform.position.x > rigthDoor.x) {
            if (right == null) addRoom('r');
            else {
                currentGrid = right;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().left.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = new Vector3(-5.5f, -1.5f, 0);
            }
        } //else if (/*Player is on the up door*/) {
        //     up = new Room();
        // } else if (/*Player is on the down door*/) {
        //     down = new Room();
        // }
    }

    void addRoom(char c) {
        switch(c) {
            case 'l': {
                GameObject l = Instantiate(grid1, new Vector3(0, 0, 0), Quaternion.identity);
                l.name = $"Grid_L_{roomCount}";
                roomCount++;
                l.GetComponent<Room>().roomCount = roomCount;
                l.GetComponent<Room>().right = currentGrid;
                currentGrid.GetComponent<Room>().left = l;
                currentGrid = l;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().right.SetActive(false);
                player.transform.position = new Vector3(8.5f, -1.5f, 0);
                break;
            }
            case 'r': {
                GameObject r = Instantiate(grid1, new Vector3(0, 0, 0), Quaternion.identity);
                r.name = $"Grid_R_{roomCount}";
                roomCount++;
                r.GetComponent<Room>().roomCount = roomCount;
                r.GetComponent<Room>().left = currentGrid;
                currentGrid.GetComponent<Room>().right = r;
                currentGrid = r;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().left.SetActive(false);
                player.transform.position = new Vector3(-5.5f, -1.5f, 0);
                break;
            }
        }
    }
}
