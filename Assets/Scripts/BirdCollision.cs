using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour {

    public GameObject[] upperPipes;
    public GameObject[] lowerPipes;
    public GameObject[] stages;
    public GameObject[] backgrounds;
    private GameControl gameController;
    public UIScript gameUI;
    private bool isGameOver = false;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        upperPipes = GameObject.FindGameObjectsWithTag("UpperPipe");
        lowerPipes = GameObject.FindGameObjectsWithTag("LowerPipe");
        stages = GameObject.FindGameObjectsWithTag("Stage");
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision");
        gameObject.GetComponent<BirdMovement>().StopBirdJump();
        gameUI.StopTimer();

        foreach(GameObject upperPipe in upperPipes)
        {
            upperPipe.GetComponent<ScrollObjects>().StopScrolling();
            upperPipe.GetComponent<BoxCollider2D>().enabled = false;
        }

        foreach(GameObject lowerPipe in lowerPipes)
        {
            lowerPipe.GetComponent<BoxCollider2D>().enabled = false;
        }

        foreach(GameObject stage in stages)
        {
            stage.GetComponent<ScrollObjects>().StopScrolling();
        }

        foreach(GameObject background in backgrounds)
        {
            background.GetComponent<ScrollBackground>().StopScrolling();
        }

        if(collision.gameObject.CompareTag("Stage"))
        {
            gameObject.GetComponent<BirdMovement>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            gameObject.GetComponent<Rigidbody2D>().mass = 5;
            gameObject.GetComponent<Rigidbody2D>().angularDrag = 100;
            if (!isGameOver)
            {
                gameController.GameOver();
                isGameOver = true;
            }
            //Debug.Log("Call to Gameover");

            //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //gameObject.GetComponent<BirdMovement>().StartCoroutine("GameOver");
            //Debug.Log("Before Collision: " + gameObject.GetComponent<Rigidbody2D>().velocity.y);
            //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            //Debug.Log("Stage Collision");
        }
    }
}
