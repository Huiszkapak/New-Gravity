using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject player;
    PlayerFire playerFire;

    void Start () {
        playerFire = player.GetComponent<PlayerFire>();
    }

    void Update () {
        //INPUTS
        if (Input.GetMouseButton(0))
        {
            playerFire.ShootGun();
        }

        if (Input.GetMouseButtonDown(1))
        {
            playerFire.ShootBlackHole();
        }
    }
}
