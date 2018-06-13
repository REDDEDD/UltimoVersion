using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    //public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }*/
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //GameIsPaused = false;
    }

    public void Pause()
    {
        Debug.Log("llego aqui");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(PlayerPrefs.GetString("ultima_escena"));
    }
}
