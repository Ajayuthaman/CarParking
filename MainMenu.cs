using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject exitePanel;
    public GameObject mainMenuPanel;
    public GameObject selectionpanel;
    

    public void Exit()
    {
        exitePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        mainMenuPanel.SetActive(true);
        exitePanel.SetActive(false);
    }

    public void Play()
    {
        selectionpanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Parking()
    {
        SceneManager.LoadScene("Level01");
    }

    public void CityDrive()
    {
        SceneManager.LoadScene("FreeRide");
    }
   
}
