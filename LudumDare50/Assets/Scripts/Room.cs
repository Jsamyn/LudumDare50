using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    private int roomCount;

    [Header("Connected Rooms")]
    private GameObject left = null;
    private GameObject right = null;
    private GameObject up = null;
    private GameObject down = null;
    [Header("Door Locations")]
    public Vector3 leftDoor = new Vector3(-6.5f, -1.5f, 0);
    public Vector3 rightDoor = new Vector3(9, -1.5f, 0);
    public Vector3 upDoor = new Vector3(1.5f, 3, 0);
    public Vector3 downDoor = new Vector3(1.5f, -6.5f, 0);
    [Header("Teleportation Locations")]
    public Vector3 leftDoorTP = new Vector3(9, -1.5f, 0);
    public Vector3 rightDoorTP = new Vector3(6, -1.5f, 0);
    public Vector3 upDoorTP = new Vector3(1.5f, -6, 0);
    public Vector3 downDoorTP = new Vector3(1.5f, 3, 0);

    private GameObject player;

    private GameObject currentGrid;
    [Header("Possible Connected Rooms")]
    public GameObject[] grids = new GameObject[3];

    // Start is called before the first frame update
    void Awake() {
        currentGrid = this.gameObject;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if (player.transform.position.x < leftDoor.x + 0.25f && 
                player.transform.position.x > leftDoor.x - 0.25f && 
                player.transform.position.y < leftDoor.y + 0.25f &&
                player.transform.position.y > leftDoor.y - 0.25f) {
            if (left == null) addRoom('l');
            else {
                left.GetComponent<Room>().currentGrid = left;
                currentGrid = left;
                currentGrid.GetComponent<Room>().right.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = currentGrid.GetComponent<Room>().leftDoorTP;
            }
        } else if (player.transform.position.x > rightDoor.x - 0.25f &&
                player.transform.position.x < rightDoor.x + 0.25f && 
                player.transform.position.y < rightDoor.y + 0.25f &&
                player.transform.position.y > rightDoor.y - 0.25f) {
            if (right == null) addRoom('r');
            else {
                right.GetComponent<Room>().currentGrid = right;
                currentGrid = right;
                currentGrid.GetComponent<Room>().left.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = currentGrid.GetComponent<Room>().rightDoorTP;
            }
        } else if (player.transform.position.y > upDoor.y - 0.25f &&
                player.transform.position.y < upDoor.y + 0.25f &&
                player.transform.position.x > upDoor.x - 0.25f &&
                player.transform.position.x < upDoor.x + 0.25f) {
            if (up == null) addRoom('u');
            else {
                up.GetComponent<Room>().currentGrid = up;
                currentGrid = up;
                currentGrid.GetComponent<Room>().down.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = currentGrid.GetComponent<Room>().downDoorTP;
            }
        } else if (player.transform.position.y < downDoor.y + 0.25f &&
                player.transform.position.y > downDoor.y - 0.25f &&
                player.transform.position.x > downDoor.x - 0.25f &&
                player.transform.position.x < downDoor.x + 0.25f) {
            if (down == null) addRoom('d');
            else {
                down.GetComponent<Room>().currentGrid = down;
                currentGrid = down;
                currentGrid.GetComponent<Room>().up.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = currentGrid.GetComponent<Room>().upDoorTP;
            }
        }
    }

    void addRoom(char c) {
        int rand = Random.Range(0, grids.Length);
        switch(c) {
            case 'l': {
                GameObject l = Instantiate(grids[rand], new Vector3(0, 0, 0), Quaternion.identity);
                l.name = $"Grid_L_{roomCount}";
                roomCount++;
                l.GetComponent<Room>().roomCount = roomCount;
                l.GetComponent<Room>().right = currentGrid;
                currentGrid.GetComponent<Room>().left = l;
                currentGrid = l;
                currentGrid.GetComponent<Room>().right.SetActive(false);
                player.transform.position = currentGrid.GetComponent<Room>().leftDoorTP;
                break;
            }
            case 'r': {
                if (rand == 2) rand = 1;
                GameObject r = Instantiate(grids[rand], new Vector3(0, 0, 0), Quaternion.identity);
                r.name = $"Grid_R_{roomCount}";
                roomCount++;
                r.GetComponent<Room>().roomCount = roomCount;
                r.GetComponent<Room>().left = currentGrid;
                currentGrid.GetComponent<Room>().right = r;
                currentGrid = r;
                currentGrid.GetComponent<Room>().left.SetActive(false);
                player.transform.position = currentGrid.GetComponent<Room>().rightDoorTP;
                break;
            }
            case 'u':{
                GameObject u = Instantiate(grids[rand], new Vector3(0, 0, 0), Quaternion.identity);
                u.name = $"Grid_U_{roomCount}";
                roomCount++;
                u.GetComponent<Room>().roomCount = roomCount;
                u.GetComponent<Room>().down = currentGrid;
                currentGrid.GetComponent<Room>().up = u;
                currentGrid = u;
                currentGrid.GetComponent<Room>().down.SetActive(false);
                player.transform.position = currentGrid.GetComponent<Room>().downDoorTP;
                break;
            }
            case 'd':{
                if (rand == 1) rand = 2;
                GameObject d = Instantiate(grids[rand], new Vector3(0, 0, 0), Quaternion.identity);
                d.name = $"Grid_D_{roomCount}";
                roomCount++;
                d.GetComponent<Room>().roomCount = roomCount;
                d.GetComponent<Room>().up = currentGrid;
                currentGrid.GetComponent<Room>().down = d;
                currentGrid = d;
                currentGrid.GetComponent<Room>().up.SetActive(false);
                player.transform.position = currentGrid.GetComponent<Room>().upDoorTP;
                break;
            }
        }
    }
}
