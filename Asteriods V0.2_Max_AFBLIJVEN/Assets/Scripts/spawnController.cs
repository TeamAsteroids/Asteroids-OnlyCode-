using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnController : MonoBehaviour
{

    // Use this for initialization
    private int i = 0;
    private int tele_num;
    private int prefeb_num;
    public Transform[] teleport;
    public GameObject[] prefeb;
    public GameObject ship;
    private Camera cam;
    public float radius = 10f;


    void Start()
    {
        cam = GetComponent<Camera>();
  

    }
    private void Update()
    {

        SpawnRandom(prefeb[0],ship);
        
    }

    void Spawn()
    {
        tele_num = Random.Range(0, 8);
        prefeb_num = Random.Range(0, 3);

        Instantiate(prefeb[prefeb_num], teleport[tele_num].position, teleport[tele_num].rotation);
    }


    public void SpawnRandom(GameObject gameobject, GameObject playerObject)
    {
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane+5)); //will get the middle of the screen


        Vector3 playerPos = playerObject.transform.position;


        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

   
        BoxCollider2D jeff = new BoxCollider2D();
        Debug.Log(Physics2D.OverlapCircle(screenPosition, radius));
         if (Physics2D.OverlapCircle(playerPos, radius) == jeff || Physics2D.OverlapCircle(playerPos, radius) == null)
        {
            // found something
            Instantiate(gameobject, screenPosition, Quaternion.identity);


        }
        else
        {
            //Instantiate(gameobject, screenPosition, Quaternion.identity);

        }
      
    }
}