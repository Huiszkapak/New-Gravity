using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour
{
    public Transform shotSpawn;
    public Vector2 directionShoot;
    public Vector2 projectileHeading;
    Vector2 targetShoot;

    public float fireRate;
    public GameObject bullet;
    float nextFire;
    
    public int bhCounter;
    public GameObject blackHole;

    Rigidbody2D playerRb;
    PlayerManager playerManager;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        targetShoot = playerManager.targetPos - playerRb.position;
        directionShoot = targetShoot.normalized;
        projectileHeading = new Vector2(directionShoot.x, directionShoot.y);
    }

    public void ShootGun()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }
    }

    public void ShootBlackHole()
    {
        if (bhCounter == 0)
        {
            bhCounter = 1;
            Instantiate(blackHole, shotSpawn.position, shotSpawn.rotation);
        }

    }
}
