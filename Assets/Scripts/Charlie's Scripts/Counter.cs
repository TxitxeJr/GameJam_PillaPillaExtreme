using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public float counter;
    public KidBehaviour kid;
    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Kids = GameObject.FindGameObjectsWithTag("Kid");
        counter = Kids.Length;
       

    }
}
