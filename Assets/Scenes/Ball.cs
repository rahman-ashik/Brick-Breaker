using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb; //a rigidbody gets force
    public float ballForce = 5f; 
    public bool inPlay; //to determine whether to move or stick with the paddle 
    public Transform paddlePosition; //the socket(child empty) to hold the object
    public Transform explosion; //the particle system that gets instantiated 
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //gets the rigidbody reference
        rb.AddForce(Vector2.up * ballForce); //adds some force upword
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bottom")) 
        {
            inPlay = false;
            gameManager.UpdateLives();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("brick"))
        {
            Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation); //instances the particle of explosion
            Destroy(newExplosion.gameObject, 1f); //destroying the instances
            Destroy(collision.gameObject); //destroying the brick object
            gameManager.UpdateScores();
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddlePosition.position; //if not in play, it sticks with paddle socket
        }

        if (Input.GetButtonUp("Jump")) //if spacebar is tapped
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            inPlay = true; //spacebar will toggle inPlay
            rb.AddForce(Vector2.up * ballForce);

            // spacebar makes the ball transform and reset to paddle socket, fix it !!!! (&&inPlay==false) might fix it

        }
    }
}
