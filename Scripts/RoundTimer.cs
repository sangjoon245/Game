using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour
{
    public static float clock;
    Text timer;

    void Start()
    {
        timer = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        if(clock <= 0f)
        {
            clock = 0f;
        }

        float currentTime = clock;

        int minute = (int) (currentTime / 60f);
        currentTime -= minute * 60;
        int seconds = (int)currentTime;
        if(seconds <= 10)
        {
            timer.text = minute + ":0" + seconds;
        } else
        {
            timer.text = minute + ":" + seconds;
        }
        


        clock -= Time.deltaTime;
    }


    public void SetTimer(int _time)
    {
        clock = (float) _time;
        Debug.Log("Time set to " + clock);
    }

}
