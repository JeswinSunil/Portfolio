using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public FirstPersonController _player;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
                GameIsPaused = false;
            }
            else
            {
                Pause();
                GameIsPaused = true;
            }
        }
    }
     public void Resume()
    {
        pauseMenuUI.SetActive(false);
        _player.enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        _player.enabled = false;
        Time.timeScale = 0f;
    }
    public void Test()
    {
        Debug.Log("Func calling");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Debug.Log("Quiting......");
        Application.Quit();
    }

}
