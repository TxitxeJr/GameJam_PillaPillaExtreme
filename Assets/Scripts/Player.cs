using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private float current_speed = 0;
    private float current_speed2 = 0;
    private Rigidbody2D rb2D;
    public GameObject Lantern;

    enum Movement { STILL, RIGHT, LEFT, UP, DOWN };
    private Movement mov;

    private Animator anim;

    private int runningLID;
    private int runningRID;
    private int runningUID;
    private int runningDID;

    private bool isRunningL;
    private bool isRunningR;
    private bool isRunningU;
    private bool isRunningD;

    void Start()
    {
        mov = Movement.STILL;
        rb2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        isRunningL = false;
        isRunningR = false;
        isRunningU = false;
        isRunningD = false;

        runningLID = Animator.StringToHash("isRunningL");
        runningRID = Animator.StringToHash("isRunningR");
        runningUID = Animator.StringToHash("isRunningU");
        runningDID = Animator.StringToHash("isRunningD");

        Lantern.transform.localRotation = Quaternion.Euler(Lantern.transform.localPosition.x, Lantern.transform.localPosition.y, 180);
        Lantern.transform.localPosition = new Vector3(3f, -10f, 0);
    }

    void Update()
    {
        isRunningL = false;
        isRunningR = false;
        isRunningU = false;
        isRunningD = false;

        mov = Movement.STILL;

        if (Input.GetKey(KeyCode.W))
        {
            mov = Movement.UP;
            isRunningU = true;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            mov = Movement.DOWN;
            isRunningD = true;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            mov = Movement.LEFT;
            isRunningL = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            mov = Movement.RIGHT;
            isRunningR = true;
        }
        
        anim.SetBool(runningLID, isRunningL);
        anim.SetBool(runningRID, isRunningR);
        anim.SetBool(runningUID, isRunningU);
        anim.SetBool(runningDID, isRunningD);
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;

        switch (mov)
        {
            default:
                break;
            case Movement.STILL:
                rb2D.velocity = Vector2.zero;
                break;
            case Movement.RIGHT:
                current_speed = speed;
                rb2D.velocity = new Vector2(current_speed * delta, 0);
                Lantern.transform.localRotation = Quaternion.Euler(Lantern.transform.localPosition.x, Lantern.transform.localPosition.y, 270);
                Lantern.transform.localPosition = new Vector3(8.5f, -10f, 0);
                break;
            case Movement.LEFT:
                current_speed = -speed;
                rb2D.velocity = new Vector2(current_speed * delta, 0);
                Lantern.transform.localRotation = Quaternion.Euler(Lantern.transform.localPosition.x, Lantern.transform.localPosition.y, 90);
                Lantern.transform.localPosition = new Vector3(0, -10f, 0);
                break;
            case Movement.UP:
                current_speed = speed;
                rb2D.velocity = new Vector2(0, current_speed * delta);
                Lantern.transform.localRotation = Quaternion.Euler(Lantern.transform.localPosition.x, Lantern.transform.localPosition.y, 0);
                Lantern.transform.localPosition = new Vector3(-3f, 0, 0);
                break;
            case Movement.DOWN:
                current_speed = -speed;
                rb2D.velocity = new Vector2(0, current_speed * delta);
                Lantern.transform.localRotation = Quaternion.Euler(Lantern.transform.localPosition.x, Lantern.transform.localPosition.y, 180);
                Lantern.transform.localPosition = new Vector3(3f, -10f, 0);
                break;
        }
    }
}
