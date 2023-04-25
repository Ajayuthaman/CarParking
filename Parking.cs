using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parking : MonoBehaviour
{
    public Collider parkCheck;
    public Collider parkCheck2;

    public Renderer parkCheckRenderer;
    public Renderer parkCheckRenderer2;

    public bool isCollideWithTarget = false;
    public bool isCollideWithTarget2 = false;


    public GameObject playerCar;
    public GameObject newPostion;
    public GameObject level;
    public GameObject nextLevel;
    public GameObject ParkingInfo;

    private void Update()
    {
        if (isCollideWithTarget && isCollideWithTarget2)
        {
            if (isCollideWithTarget && isCollideWithTarget2)
            {
                ParkingInfo.SetActive(true);
                Material material = parkCheckRenderer.material;
                Material material2 = parkCheckRenderer2.material;

                Color greenColor = new Color(0, 1, 0, 0.5f); 
                material.color = greenColor;
                material2.color = greenColor;

                if (Input.GetKey(KeyCode.P))
                {
                    level.SetActive(false);
                    nextLevel.SetActive(true);
                    Vector3 targetPos = newPostion.transform.position;
                    playerCar.transform.position = targetPos;
                }
            }
        }
        else
        {
            ParkingInfo.SetActive(false);
            Material material = parkCheckRenderer.material;
            Material material2 = parkCheckRenderer2.material;

            Color redColor = new Color(1, 0, 0, 0.5f);
            material.color = redColor;
            material2.color = redColor;

        } 
    }
}
