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
    public GameObject[] prefeb;
    public GameObject ship;
    private Camera cam;
    public float radiusSchip = 1f;
    public float radiusScreen = 1000f;


    void Start()
    {
        cam = GetComponent<Camera>();

 


    }
    private void Update()
    {

            


    }



    public void SpawnRandom(GameObject gameobject, GameObject playerObject)
    {
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane+5)); //will get the middle of the screen


        Vector3 playerPos = playerObject.transform.position;


        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

   
        BoxCollider2D jeff = new BoxCollider2D();
        Debug.Log(Physics2D.OverlapCircle(screenPosition, radiusSchip));
         if (Physics2D.OverlapCircle(playerPos, radiusSchip) == jeff || Physics2D.OverlapCircle(screenPosition, radiusScreen) == null)
        {
            // found something
            //Instantiate(gameobject, screenPosition, Quaternion.identity);


        }
        else
        {
            Instantiate(gameobject, screenPosition, Quaternion.identity);

        }
      
    }
    public void asteroidspawn(int i)
    {
        int iB;
        int iM;
        iB = i / 4;
        Debug.Log(iB);
        iM = (i % 4) / 2;
        Debug.Log(iM);
        i = (i % 4) % 2;
        Debug.Log(i);
        for (int jB = 0; jB < iB; jB++)
        {
            SpawnRandom(prefeb[0], ship);
        }
        for (int jM = 0; jM < iM; jM++)
        {
            SpawnRandom(prefeb[1], ship);
        }
        for (int j = 0; j < i; j++)
        {
            SpawnRandom(prefeb[2], ship);
        }

    }
    public void spawnold()
    {
        SpawnRandom(prefeb[0], ship);

    }
}