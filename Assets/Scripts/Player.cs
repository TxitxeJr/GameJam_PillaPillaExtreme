using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private float current_speed = 0;
    private float current_speed2 = 0;
    private Rigidbody2D rb2D;
    enum Movement { STILL, RIGHT, LEFT, UP, DOWN };
    private Movement mov;
 
    void Start()
    {
        mov = Movement.STILL;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mov = Movement.STILL;

        if (Input.GetKey(KeyCode.W))
        {
            mov = Movement.UP;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            mov = Movement.DOWN;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            mov = Movement.LEFT;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            mov = Movement.RIGHT;
        }
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
                break;
            case Movement.LEFT:
                current_speed = -speed;
                rb2D.velocity = new Vector2(current_speed * delta, 0);
                break;
            case Movement.UP:
                current_speed = speed;
                rb2D.velocity = new Vector2(0, current_speed * delta);
                break;
            case Movement.DOWN:
                current_speed = -speed;
                rb2D.velocity = new Vector2(0, current_speed * delta);
                break;
        }
    }
}
