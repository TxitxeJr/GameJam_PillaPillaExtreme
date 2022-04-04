using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Camera cam;
    public GameObject pointer;
    public int counter = 0;

    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Catch();
    }

    private void FixedUpdate()
    {
        pointer.transform.position = mousePos;
    }

    private void Catch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if(hit.collider)
            {
                Destroy(hit.collider.gameObject);
                counter++;
                Debug.Log(counter);
            }
        }
    }
}
