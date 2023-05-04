using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject countDown;

    private void Update()
    {
        if (winMenu.gameObject.activeInHierarchy)
        {
            countDown.SetActive(false);
        }
    }
}
