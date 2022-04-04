using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Kid
{
    public float kidSpeed;
    public float patrolSpeed;
    public List<Transform> wayPoints;
    public Transform kidTarget;
    public float changeDistance;
    public byte nextPosition;
    public bool isOnTarget;
}
public class KidBehaviour : MonoBehaviour
{

    Rigidbody2D rb2d;
    public Kid kid;

    public SpriteRenderer niño;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        kid.isOnTarget = false;
        this.niño = GetComponent<SpriteRenderer>();
        this.niño.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        moveKid();
    }

    public void moveKid()
    {
        if (kid.isOnTarget == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, kid.kidTarget.transform.position, kid.kidSpeed * Time.deltaTime);
            
        }
        else if (kid.isOnTarget == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, kid.wayPoints[kid.nextPosition].transform.position, kid.patrolSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, kid.wayPoints[kid.nextPosition].transform.position) < kid.changeDistance)
            {
                kid.nextPosition++;
                if (kid.nextPosition >= kid.wayPoints.Count)
                {
                    kid.nextPosition = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lantern")
        {
            this.niño.enabled = true;
        } 

        if (collision.gameObject.tag == "Target")
        {
            kid.isOnTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lantern")
        {
            this.niño.enabled = false;
        }
    }
}

