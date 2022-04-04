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
    public Vector3 upDoor = new Vector3(0, 2.9f, 0);
    public Vector3 downDoor = new Vector3(0, -6, 0);
    public GameObject player;

    public GameObject currentGrid;
    public GameObject grid1;

    // Start is called before the first frame update
    void Awake() {
        currentGrid = this.gameObject;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if (player.transform.position.x < leftDoor.x) {
            if (left == null) addRoom('l');
            else {
                left.GetComponent<Room>().currentGrid = left;
                currentGrid = left;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().right.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = new Vector3(8.5f, -1.5f, 0);
            }
        } else if (player.transform.position.x > rigthDoor.x) {
            if (right == null) addRoom('r');
            else {
                right.GetComponent<Room>().currentGrid = right;
                currentGrid = right;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().left.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = new Vector3(-5.5f, -1.5f, 0);
            }
        } else if (player.transform.position.y > upDoor.y)
        {
            if (up == null) addRoom('u');
            else
            {
                up.GetComponent<Room>().currentGrid = up;
                currentGrid = up;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().down.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = new Vector3(1.5f, -5.9f, 0);
            }
        }else if (player.transform.position.y < downDoor.y)
        {
            if (down == null) addRoom('d');
            else
            {
                down.GetComponent<Room>().currentGrid = down;
                currentGrid = down;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().up.SetActive(false);
                currentGrid.SetActive(true);
                player.transform.position = new Vector3(1.5f, 2.92f, 0);
            }
        }
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
            case 'u':{
                GameObject u = Instantiate(grid1, new Vector3(0, 0, 0), Quaternion.identity);
                u.name = $"Grid_U_{roomCount}";
                roomCount++;
                u.GetComponent<Room>().roomCount = roomCount;
                u.GetComponent<Room>().down = currentGrid;
                currentGrid.GetComponent<Room>().up = u;
                currentGrid = u;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().down.SetActive(false);
                player.transform.position = new Vector3(1.5f, -5.9f, 0);
                    break;
            }
            case 'd':{
                GameObject d = Instantiate(grid1, new Vector3(0, 0, 0), Quaternion.identity);
                d.name = $"Grid_D_{roomCount}";
                roomCount++;
                d.GetComponent<Room>().roomCount = roomCount;
                d.GetComponent<Room>().up = currentGrid;
                currentGrid.GetComponent<Room>().down = d;
                currentGrid = d;
                Debug.Log(currentGrid.name);
                currentGrid.GetComponent<Room>().up.SetActive(false);
                player.transform.position = new Vector3(1.5f, 2.92f, 0);
                    break;
            }
        }
    }
}
