using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public GameObject startMenu2;
    public InputField usernameField;
    public GameObject sampleStage;
    public int teamNumber = -1;

    private void Awake()
    {
        sampleStage.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void SelectMenu2()
    {
        startMenu.SetActive(false);
        usernameField.interactable = false;
        startMenu2.SetActive(true);
    }

    public void SetTeamNumberOne()
    {
        teamNumber = 1;
        ConnectToServer();
    }

    public void SetTeamNumberTwo()
    {
        teamNumber = 2;
        ConnectToServer();
    }

    public void ConnectToServer()
    {
        startMenu2.SetActive(false);
        Client.instance.ConnectToServer(teamNumber);
        sampleStage.SetActive(true);
    }
}
