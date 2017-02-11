using UnityEngine;
using System.Collections;

public class BlackHoles : MonoBehaviour
{

    //Black holes variables
    public float maxSize;
    public float scaleUp;
    public float blackHoleSpeed;
    public float delay;
    public float baseMagnitude;
    private bool freeze;

    PlayerManager playerManager;
    PlayerFire playerFire;

    GameObject player;
    Rigidbody2D bHoleRb;


    void Start()
    {
        //Initialize Stuff
        freeze = false;
        bHoleRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerManager = player.GetComponent<PlayerManager>();
        playerFire = player.GetComponent<PlayerFire>();
    }

    void Update()
    {
        bHoleRb.velocity = playerFire.projectileHeading * blackHoleSpeed + playerManager.playerMov;

        // CONTROL RELATED STUFF
        // When right mouse button is clicked
        //-->tag Black Hole as "frozen"
        if (Input.GetMouseButtonDown(1))
        {
            freeze = true;
        }

        // When mouse button is held down 
        //-->freeze black hole, increase point effector's magnitude
        if (Input.GetMouseButton(1) && freeze == true)
        {
            bHoleRb.velocity = new Vector2(0, 0);
            GetComponent<PointEffector2D>().forceMagnitude = baseMagnitude * playerManager.movSpeed; //magnitude is relative to player's speed


            //-->Increase size up to maxSize
            if (transform.localScale.magnitude < maxSize)
            {
                transform.localScale += new Vector3(scaleUp, scaleUp, scaleUp);
            }
        }

        //Destroy Black Hole when right mouse button is clicked
        if (Input.GetMouseButtonUp(1) && freeze == true)
        {
            Destroy(gameObject);
            playerFire.bhCounter = 0;
        }

        //Destroy Black Hole after "delay" if nothing happens
        if (freeze == false)
        {
            StartCoroutine(DestroyDelay());
        }
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(delay);
        if (freeze == false)
        {
            Destroy(gameObject);
            playerFire.bhCounter = 0;
        }
    }
}
