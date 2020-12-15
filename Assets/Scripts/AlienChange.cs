using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlienChange : MonoBehaviour
{
    public GameObject ShiftRoomPanel_alien1,ShiftRoomPanel_alien2;
    public GameObject Alien1, Alien2;
    public GameObject panel;
    //public Text statname1, statname2, statname3;
    public Button Reset1, Reset2;
    public void Change()
    {
        panel.SetActive(true);
    }

    private void Update()
    {
        if (Alien1.activeInHierarchy)
        {
            Reset1.gameObject.SetActive(true);
            Reset2.gameObject.SetActive(false);
        }

        if (!Alien2.activeInHierarchy) return;
        Reset2.gameObject.SetActive(true);
        Reset1.gameObject.SetActive(false);
    }

    public void Close()
    {
        panel.SetActive(false);
    }

    public void ChangeAlien1()
    {
        Alien1.SetActive(false);
        Alien2.SetActive(true);
        panel.SetActive(false);
        ShiftRoomPanel_alien1.SetActive(false);
        ShiftRoomPanel_alien2.SetActive(true);
        
    }
    public void ChangeAlien2()
    {
        Alien2.SetActive(false);
        Alien1.SetActive(true);
        panel.SetActive(false);
        ShiftRoomPanel_alien2.SetActive(false);
        ShiftRoomPanel_alien1.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("PetAlien");
    }
    
}
