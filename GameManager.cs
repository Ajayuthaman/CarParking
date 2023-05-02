using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public GameObject pauseMenu;
    public GameObject carControll;
    public GameObject level1;
    public GameObject winningMenu;
    public GameObject parkingButton;
    public GameObject levelFail;

    private void Update()
    {
        if (winningMenu.activeInHierarchy)
        {
            carControll.SetActive(false);
            parkingButton.SetActive(false);
        }
    }

    public void LevelPause()
    {
        carControll.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        carControll.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }


    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void LevelFail()
    {
        carControll.SetActive(false);
        levelFail.SetActive(true);
        Time.timeScale = 0;        
    }
}
