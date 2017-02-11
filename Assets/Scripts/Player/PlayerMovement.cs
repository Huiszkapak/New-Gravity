using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public Vector2 playerMov;

    PlayerManager playerManager;
    Rigidbody2D playerRb;

    // Use this for initialization
    void Start () {
        playerManager = GetComponent<PlayerManager>();
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.velocity = playerManager.initialSpeed;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
