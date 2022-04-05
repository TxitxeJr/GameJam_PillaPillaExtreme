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
    public bool isCatched;
    public bool isMoving;
    Rigidbody2D rb2d;
    public Kid kid;
    public SpriteRenderer niño;
    public GameObject leftFoot;
    public GameObject rightFoot;
    public float nextLeftFootTime;
    public float leftFootRate;
    public float nextRightFootTime;
    public float rightFootRate;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        kid.isOnTarget = false;
        this.niño = GetComponent<SpriteRenderer>();
        this.niño.enabled = false;
        isCatched = false;
        isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        moveKid();
        if(this.niño.enabled == true && Input.GetKeyDown(KeyCode.Space))
        {
            isCatched = true;
            isMoving = false;
            Destroy(this.gameObject);
        }
        if (isMoving)
        {
            RightFoot();
            LeftFoot();
        }
    }

    public void moveKid()
    {
        isMoving = true;
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

    public void LeftFoot()
    {
        if(Time.time > nextLeftFootTime)
        {
            nextLeftFootTime = Time.time + leftFootRate;
            Instantiate(leftFoot, transform.position, transform.rotation);
            Destroy(leftFoot, 5f);
        }
    }
    public void RightFoot()
    {
        if (Time.time > nextRightFootTime)
        {
            nextRightFootTime = Time.time + rightFootRate;
            Instantiate(rightFoot, transform.position, transform.rotation);
            Destroy(rightFoot, 5f);
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

