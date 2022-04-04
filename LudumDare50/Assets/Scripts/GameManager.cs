using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // The bigger the value the easier
    public static float DEFAULT_DIFFICULTY_SCALE = 30f;
    public static float DEFAULT_TIME = 180f;
    public static int DEFAULT_DIFFICULTY = 1;
    public static int DEFAULT_TIMER_START = 1;

    public float timerMax;
    public bool timerIsRunning;
    public int difficulty;
    public float treeTimer;
    private static int WATER_LOWER_LIMIT = 1;
    private static int WATER_UPPER_LIMIT = 4;

    // Start is called before the first frame update
    void Start() {
        if (PlayerPrefs.HasKey("difficulty")) difficulty = PlayerPrefs.GetInt("difficulty");
        if (PlayerPrefs.HasKey("treeTimer")) treeTimer = PlayerPrefs.GetFloat("treeTimer");
        if (PlayerPrefs.HasKey("timerIsRunning")) {
            int temp = PlayerPrefs.GetInt("timerIsRunning");
            if (temp == 1) timerIsRunning = true;
            else timerIsRunning = false;
        }
        timerMax = treeTimer;
    }

    // Update is called once per frame
    void Update() {
        if (treeTimer < timerMax - DEFAULT_DIFFICULTY_SCALE) {
            difficulty++;
            timerMax -= DEFAULT_DIFFICULTY_SCALE;
        }
        if (timerIsRunning) {
            if (treeTimer > 0) treeTimer -= Time.deltaTime;
            else {
                timerIsRunning = false;
                treeTimer = 0f;
                PlayerPrefs.DeleteAll();
            }
        }
        Debug.Log(treeTimer);
    }

    public void save() {
        PlayerPrefs.SetInt("difficulty", difficulty);
        PlayerPrefs.SetFloat("treeTimer", treeTimer);
        if (timerIsRunning) PlayerPrefs.SetInt("timerIsRunning", 1);
        else PlayerPrefs.SetInt("timerIsRunning", 0);
    }

    public void addWater() {
        int rand = Random.Range(WATER_LOWER_LIMIT, WATER_UPPER_LIMIT);
        treeTimer += rand * DEFAULT_DIFFICULTY_SCALE * 2;
        timerMax = treeTimer;
        if (difficulty > rand) difficulty -= rand;
    }

    void newGame() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("difficulty", DEFAULT_DIFFICULTY);
        PlayerPrefs.SetFloat("treeTimer", DEFAULT_TIME);
        PlayerPrefs.SetInt("timerIsRunning", DEFAULT_TIMER_START);
    }
}