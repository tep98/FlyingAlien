using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject pauseMenu;
    public GameObject panelUI;

    public AudioSource bgAudio;

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        if(GameIsPause){
          Resume();
        }
        else
        {
          Pause();
        }
      }
    }

    public void Resume()
    {
       pauseMenu.SetActive(false);
       panelUI.SetActive(true);
       Time.timeScale = 1f;
       GameIsPause = false;
       bgAudio.pitch = 1f;
    }

    public void Pause()
    {
      pauseMenu.SetActive(true);
      panelUI.SetActive(false);
      Time.timeScale = 0f;
      GameIsPause = true;
      bgAudio.pitch = 0.95f;
    }

    public void LoadMenu()
    {
      Resume();
      SceneManager.LoadScene("MainMenu");
    }
}
