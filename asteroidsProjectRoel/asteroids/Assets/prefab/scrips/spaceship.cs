using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spaceship : MonoBehaviour {

    // Use this for initialization

    public float        bulletForce;
    public float        deathForce;


    public int          lives;
    public int          score;
    public GameObject   bullet;
    public GameObject   gameOverPannel;

    private float       thrustInput;
    private float       turnInput;

    public Color        inColor;
    public Color        normalColor;

    public Text         scoreText;
    public Text         liveText;

    void Start () {
        score = 0;

        gameOverPannel.SetActive(false);
        scoreText.text = "score " + score;
        liveText.text = "leves " + lives;
	}
	
	// Update is called once per frame
	void Update ()
    {

        //input fireKey

        if (Input.GetButtonDown("Fire1"))
        {
           GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * bulletForce);
            Destroy (newBullet, 3.0f);
        }


   

    }
    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrustInput);
        //rb.AddTorque(-turnInput);
    }

    void ScorePoints(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "score " + score;
    }
    
    void Respawn()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;
        sr.color = inColor;
        Invoke("Invulnerable", 3f);
    }

    void Invulnerable()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = normalColor;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > deathForce)
        {
            lives--;
            liveText.text = "Lives " + lives;
            //respan new live
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Invoke("Respawn", 3f);
                
            if (lives<= 0)
            {
                //gameover
                GameOver();
            }
            
           
        }
        
    }
    void GameOver()
    {
        CancelInvoke();
        gameOverPannel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }
}
