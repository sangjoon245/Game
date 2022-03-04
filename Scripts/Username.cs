using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    Text username;

    void Start()
    {
        
    }


    public void SetUsername(string _username)
    {
        username = GetComponent<Text>();
        Debug.Log("FINALE, THE USERNAME IS " + _username);
        username.text = _username;
    }

}
