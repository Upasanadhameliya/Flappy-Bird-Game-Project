using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour {

    //private GameObject parent;
    //public bool upperPipe = false;
    //RandomisePosition rp;

    public Vector2 speed = new Vector2(-4,0);
    private Rigidbody2D rb;
    private bool canScroll = true;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () {
        if (canScroll)
        {
            if (transform.position.x > -20)
            {
                rb.MovePosition(rb.position + speed * Time.fixedDeltaTime);
                //if(!upperPipe) Debug.Log("Normal: " + rb.position);
            }
            else
            {
                //Debug.Log("Call");
                rb.MovePosition(rb.position + new Vector2(40, 0));
            }
        }
    }

    public void StopScrolling()
    {
        canScroll = false;
    }

    /*void Randomise()
    {
        float range = Random.Range(-1.9f, 3.9f);
        rb.MovePosition(rb.position * Vector2.up * range);
        parent.transform.GetChild(1).rigidbody2D.MovePosition()
    }*/

    /*public void ChangePosition()
    {
        Debug.Log("Call");
        rb.MovePosition(rb.position + Vector2.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("RandomisingTrigger"))
        {
            ChangePosition();
        }
    }*/
}
