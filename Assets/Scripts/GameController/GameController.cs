using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject player;

    public bool gameStarted;
    public bool gameFinished;

    PlayerManager playerManager;

	void Start () {
        gameStarted = true;
        playerManager = player.GetComponent<PlayerManager>();

    }

    void Update () {
        if (playerManager.playerDead)
        {
            LoseGame();
        }
    }

    void LoseGame()
    {
        Destroy(player.gameObject);
        gameFinished = true;
    }
}
