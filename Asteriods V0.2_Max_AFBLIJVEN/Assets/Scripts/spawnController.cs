using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnController : MonoBehaviour {

    // Use this for initialization
    public int m_CurrentSpawnCount = 0, SpawnCount = 10;
    public GameObject Enemy;
    private int tele_num;
    private int prefeb_num;
    public Transform[] teleport;
    public GameObject[] prefeb;
    private Camera cam;
    internal int asteroidsRemaining;
    internal int wave;
    internal int increaseEachWave = 4;
    public GameObject asteroid;
    public Text waveText;

    void Start()
    {
        cam = GetComponent<Camera>();
        Spawn();

    }
    private void Update()
    {
        SpawnRandom(prefeb[0]);
    }

    void Spawn()
    {
        tele_num = Random.Range(0, 8);
        prefeb_num = Random.Range(0, 3);

        Instantiate(prefeb[prefeb_num], teleport[tele_num].position, teleport[tele_num].rotation);
    }
    void SpawnAsteroids()
    {

        //DestroyExistingAsteroids();

        // Decide how many asteroids to spawn
        // If any asteroids left over from previous game, subtract them
        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < asteroidsRemaining; i++)
        {

            // Spawn an asteroid
            Instantiate(asteroid,
                new Vector3(Random.Range(-9.0f, 9.0f),
                    Random.Range(-6.0f, 6.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        }

        waveText.text = "WAVE: " + wave;
    }
    void DestroyExistingAsteroids()
    {
        GameObject[] asteroids =
            GameObject.FindGameObjectsWithTag("Large Asteroid");

        foreach (GameObject current in asteroids)
        {
            GameObject.Destroy(current);
        }

        GameObject[] asteroids2 =
            GameObject.FindGameObjectsWithTag("Small Asteroid");

        foreach (GameObject current in asteroids2)
        {
            GameObject.Destroy(current);
        }
    }

    public void SpawnRandom(GameObject gameobject)
    {
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane+5)); //will get the middle of the screen

        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        Instantiate(gameobject, screenPosition, Quaternion.identity);
    }
    //void CreateTransform()
    //{
    //    double randw = randomize(boxw / 2, boxw / 2 * -1);
    //    double randh = randomize(boxh / 2, boxh / 2 * -1);
    //    double randd = randomize(boxd / 2, boxd / 2 * -1);
    //}

}
