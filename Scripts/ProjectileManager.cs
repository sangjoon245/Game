using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public int id;
    public int type; //10001 for knives, //10002 for shadow

    public void Initialize(int _id)
    {
        id = _id;
    }

    public void SetType(int _id)
    {
        type = _id;
    }

    public void Destroy()
    {
        Debug.Log("This has been called!");
        Destroy(this.gameObject);
    }
    

}