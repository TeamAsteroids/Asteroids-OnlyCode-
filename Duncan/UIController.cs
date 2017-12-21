using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject playerPrefab;
    GameObject playerInstance;

    public int numLives = 4;
    float respawnTimer;
    public double wave = 1;

    // Use this for initialization
    void Start () {
        SpawnPlayer();
	}

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (playerInstance == null && numLives > 1)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }

    void OnGUI()
    {
        if (numLives > 1 || playerInstance != null)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over!");
        }

        WaveUpdate();
    }

    void WaveUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            wave += 0.5;
        }

        GUI.Label(new Rect(100, 0, 300, 200), "Wave: " + wave);

    }
}
