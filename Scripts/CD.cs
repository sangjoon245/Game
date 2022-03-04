using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CD : MonoBehaviour
{

    public static float cdvalue = 0;
    Text cd;
    public Image image;

    void Start()
    {
        this.cd = GetComponent<Text>();
    }

    public void Update()
    {
        if(cdvalue == 0)
        {
            cd.text = "";
        } else
        {
            cd.text = "" + (Mathf.Abs(Mathf.Round(cdvalue * 10f) / 10f));
        }
        
    }

    public void FixedUpdate()
    {
        if (cdvalue <= 0)
        {
            image.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            cdvalue = 0;
        } else
        {
            cdvalue -= Time.deltaTime;
            image.GetComponent<Image>().color = new Color32(50, 50, 50, 255);
        }
        

    }

    public void setCD(float _cd)
    {
        cdvalue = _cd;
    }

}


