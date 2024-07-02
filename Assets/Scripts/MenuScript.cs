using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public bool menuActive = false;
    public GameObject menuUI;


    public void Start()
    {
        menuUI.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (menuActive == false)
            {
                menuUI.SetActive(true);
                menuActive = true;
            }
            else
            {
                menuUI.SetActive(false);
                menuActive = false;
            }
        }
        
    }

    public void doExitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
       
    }
}
