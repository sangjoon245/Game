using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
   
    void Start()
    {
        
    }


    public void ScoreIncrement()
    {
        score = GetComponent<Text>();
        scoreValue++;
        score.text = "" + scoreValue;
    }

    public void SetScore(int _score)
    {
        score = GetComponent<Text>();
        scoreValue = _score;
        score.text = "" + scoreValue;
    }


}
