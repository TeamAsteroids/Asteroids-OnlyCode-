using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1 : MonoBehaviour {

    public Rigidbody2D  rb;

    

    public int          asteroidSize; //3 = largde. 2 = mid. 1 = small.

    public GameObject   asteroidMid;
    public GameObject   asteroidSmall;
    public GameObject   player;
    public int          points;

    // Use this for initialization
    void Start () {
      

        
    } 
	
	// Update is called once per frame
	void Update () {
        

        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check to see if bullet
        if (other.CompareTag("bullet"))
        {
            //check size of the asteroid. and spann next size
            if(asteroidSize == 3)
            {
                //plit in smaller span in nummber 2

                GameObject asteroid1 = Instantiate(asteroidMid, transform.position, transform.rotation);
                GameObject asteroid2 = Instantiate(asteroidMid, transform.position, transform.rotation);

            }
            else if (asteroidSize == 2)
            {
                //plit in smaller span in nummber 1

                GameObject asteroid1 = Instantiate(asteroidSmall, transform.position, transform.rotation);
                GameObject asteroid2 = Instantiate(asteroidSmall, transform.position, transform.rotation);
                GameObject asteroid3 = Instantiate(asteroidSmall, transform.position, transform.rotation);
                
            }
            else if (asteroidSize == 1)
            {
       
            }

            player.SendMessage("ScorePoints", points);

            //desteroy Asteroid
            Destroy(gameObject);

            //destroy bullet
            Destroy(other.gameObject);

        }
    }
}
