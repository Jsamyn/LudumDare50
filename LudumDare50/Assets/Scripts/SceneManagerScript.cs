using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Launch") Time.timeScale = 0f;
        if (!(PlayerPrefs.HasKey("difficulty") &&
            PlayerPrefs.HasKey("treeTimer") &&
            PlayerPrefs.HasKey("timerIsRunning")))
        GameObject.Find("Continue Game Button").GetComponent<Button>().interactable = false;
    }

    public void newGame() {
        GameObject.Find("Game Manager").GetComponent<GameManager>().enabled = true;
        Time.timeScale = 1f;
        // This it to load the first scene
        SceneManager.LoadScene("Scenes/Logan_Work");
    }

    public void continueGame() {
        Time.timeScale = 1f;
        // This is load where the player left off
        SceneManager.LoadScene("Scenes/Logan_Work");
    }
}
