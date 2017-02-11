using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    GameObject player;
    Rigidbody2D bulletRb;

    PlayerFire playerFire;
    PlayerManager playerManager;

    void Start()
    {
        player = GameObject.Find("Player");
        playerFire = player.GetComponent<PlayerFire>();
        playerManager = player.GetComponent<PlayerManager>();
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = playerFire.projectileHeading * bulletSpeed + playerManager.playerMov;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
