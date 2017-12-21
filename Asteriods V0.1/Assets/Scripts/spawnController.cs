using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {

    // Use this for initialization
    public int m_CurrentSpawnCount = 0, SpawnCount = 10;
    public GameObject Enemy;
    private int tele_num;
    private int prefeb_num;
    public Transform[] teleport;
    public GameObject[] prefeb;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        Spawn();

    }
    private void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(teleport[0].position);
        Debug.Log("target is " + screenPos.x + " pixels from the left");
        Debug.Log(screenPos.y);
    }

    void Spawn()
    {
        tele_num = Random.Range(0, 8);
        prefeb_num = Random.Range(0, 3);

        Instantiate(prefeb[prefeb_num], teleport[tele_num].position, teleport[tele_num].rotation);
    }
    //void CreateTransform()
    //{
    //    double randw = randomize(boxw / 2, boxw / 2 * -1);
    //    double randh = randomize(boxh / 2, boxh / 2 * -1);
    //    double randd = randomize(boxd / 2, boxd / 2 * -1);
    //}

}
