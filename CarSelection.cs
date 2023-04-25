using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [Header("Buttons & Canvas")]
    public Button nextButton;
    public Button prevButton;

    private int currentCar;
    public GameObject[] carList;


    public void NextCar()
    {
        if(currentCar != carList.Length-1)
        {    
            currentCar++;
        }
        else
        {
            currentCar = 0;
        }

        foreach(var car in carList)
        {
            car.SetActive(false);
        }
        carList[currentCar].SetActive(true);
    }

    public void PrevCar()
    {
        if (currentCar != 0)
        {
            prevButton.interactable = true;
            currentCar--;
        }
        else
        {
            currentCar = carList.Length - 1;
        }
        foreach (var car in carList)
        {
            car.SetActive(false);
        }
        carList[currentCar].SetActive(true);
    }
}
