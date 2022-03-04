using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Announcer : MonoBehaviour
{
    Text announcer;


    public void SetText(string _text)
    {
        announcer = GetComponent<Text>();
        announcer.text = "" + _text;
    }
}
