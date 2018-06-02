using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour {

    public static bool isGamePaused = false;
    public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == true)
            {
                Resume();
            }
            else if (isGamePaused == false)
            {
                Pause();
            }
        }
	}

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        ManageScenes.instance.LoadMainMenu();
    }
}
