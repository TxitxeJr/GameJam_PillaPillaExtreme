using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Camera cam;
    public GameObject pointer;
    
    

    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    private void FixedUpdate()
    {
        pointer.transform.position = mousePos;
    }

    
}
