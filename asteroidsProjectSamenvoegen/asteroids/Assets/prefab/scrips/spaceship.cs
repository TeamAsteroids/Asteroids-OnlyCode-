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
        liveText.text = "levens " + Lives;
        Invoke("Invulnerable", 2f);
	}
	
	// Update is called once per frame
	void Update ()
    {

        //input fireKey
        if (Lives > 0 )
        {
            gameOverPannel.SetActive(false);
        }

        liveText.text = "Lives " + Lives;
        if (Lives <= 0)
        {
            //gameover
            GameOver();

            gameOverPannel.SetActive(true);

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

   
        GetComponent<Collider2D>().enabled = false;

        Invoke("Invulnerable", 2f);
    }

    void Invulnerable()
    {
        GetComponent<Collider2D>().enabled = true;
        //GetComponent<SpriteRenderer>().color = normalColor;
        Debug.Log("vunerable");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > 0.03f) {
            GetComponent<Collider2D>().enabled = false;
            Invoke("Respawn", 0.2f);
            Lives--;





            if (Lives <= 0)
            {
                //gameover
                GameOver();
                PlayerMovement move = GetComponent<PlayerMovement>();
                PlayerShooting shoot = GetComponent<PlayerShooting>();
                shoot.enabled = false;
                move.enabled = false;
                Debug.Log(gameOverPannel.scene) ;
               




            }

        }




    }
    void GameOver()
    {

        //or 
        //GameObject Script = GameObject.Find("highscore") ;
        //ScoreMenuController other = new ScoreMenuController();
        //other.Invoke("OnGui", 0f);
        //other.SetActive(false);
        //Debug.Log(Script);
        //Script.SetActive(true);
        
        CancelInvoke();
        //GetComponent<HighScore>().Invoke("start", 2f);


    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }
}
