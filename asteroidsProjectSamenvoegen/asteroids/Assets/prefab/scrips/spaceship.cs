using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spaceship : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D  rb;
    public float        bulletForce;
    public float        deathForce;


    public int          Lives;
    public int          score;
    public GameObject   gameOverPannel;


    public Color        inColor;
    public Color        normalColor;

    public Text         scoreText;
    public Text         liveText;

    void Start () {
        score = 0;

        gameOverPannel.SetActive(false);
        scoreText.text = "score " + score;
        liveText.text = "leves " + Lives;
	}
	
	// Update is called once per frame
	void Update ()
    {

        //input fireKey

        liveText.text = "Lives " + Lives;
        if (Lives <= 0)
        {
            //gameover
            GameOver();


        }


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

   
        GetComponent<Collider2D>().enabled = true;

        Invoke("Invulnerable", 2f);
    }

    void Invulnerable()
    {
        GetComponent<Collider2D>().enabled = true;
        //GetComponent<SpriteRenderer>().color = normalColor;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = false;
        Invoke("Respawn", 0.2f);
            Lives--;
            
          


                
            if (Lives <= 0)
            {
                //gameover
                GameOver();
             

        }




    }
    void GameOver()
    {
        ScoreMenuController other = new ScoreMenuController();
        other.Invoke("OnGui", 0f);
        
        CancelInvoke();
        //GetComponent<HighScore>().Invoke("start", 2f);


    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }
}
