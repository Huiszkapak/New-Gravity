using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float lifePoints;
    public float lifeDown;
    public float lifeMax;
    public float resistPoints;
    public float resistDown;
    public float resistUp;
    public float resistMax;
    public bool playerDead;

    public int scoreCounter;

    public Vector2 initialSpeed;
    public Vector2 playerMov;
    public float movSpeed;
    public Vector2 targetPos;

    Rigidbody2D playerRb;

    void Start()
    {
        initialSpeed = new Vector2(7.6f, 0);
        playerRb = GetComponent<Rigidbody2D>();
        lifePoints = lifeMax;
        resistPoints = resistMax;
    }

    void Update()
    {
        //RESIST
        if (resistPoints < resistMax)
        {
            resistPoints += resistUp;
        }

        if (resistPoints > resistMax)
        {
            resistPoints = resistMax;
        }
        
        //DEATH
        if (lifePoints <= 0)
        {
            playerDead = true;
        }
    }

    void FixedUpdate()
    {
        //SPEED AND DIRECTION
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPos - playerRb.position);        
        playerMov = playerRb.velocity;
        movSpeed = playerMov.magnitude;
    }

    //COLLISIONS AND TRIGGERS
    void OnTriggerStay2D(Collider2D other)
    {
        // INTERACTION WITH BLACK HOLES
        if (other.tag == "Black Hole")
        {
            GameObject bHole = GameObject.Find("Black Hole(Clone)");
            Vector2 bHolePos = bHole.transform.position;
            Vector2 bHoleDirection = bHolePos - playerRb.position;
            float bHoleDistance = bHoleDirection.magnitude;

            //When object is in black hole's influence zone
            //-->Start decreasing resistance
            if (bHoleDistance <= 5.0f)
            {
                resistPoints -= resistDown / bHoleDistance;
                if (resistPoints <= 0.0f)
                {
                    lifePoints -= lifeDown / bHoleDistance;
                }
            }
        }
    }
}