using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public float counter;
    public KidBehaviour kid;
    public Text text;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Kids = GameObject.FindGameObjectsWithTag("Kid");
        counter = Kids.Length;
        text.text = "" + Mathf.Round(counter);

    }
}
