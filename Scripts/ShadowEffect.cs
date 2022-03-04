using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEffect : MonoBehaviour
{

    private float timeBeforeDestroy = 0.25f;
    private float fadeSpeed = 5f;
    private float currentTime;
    
    void Awake()
    {
        currentTime = timeBeforeDestroy;
    }

    void Update()
    {

        Color objectColor = this.GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        this.GetComponent<Renderer>().material.color = objectColor;

        currentTime -= Time.deltaTime;
        if(currentTime <= 0f)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(parent.gameObject);
    }
}
