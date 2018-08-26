using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public float force;
    public float gravity = 1f;
    private bool canJump = true;
    private bool jumping = false;
    public float coolDownTime = 0.5f;
    private bool isGameOver = false;
    //public Animator anim;

    void FixedUpdate()
    {
        if (!isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (canJump)
                {
                    //anim.SetInteger("Rotation", 1);
                    rb.AddForce(Vector2.up * force * Time.fixedDeltaTime);
                    canJump = false;
                    jumping = true;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                canJump = true;
            }

            if (!jumping)
            {
                //anim.SetInteger("Rotation", 0);
                rb.AddForce(Vector2.down * gravity * Time.fixedDeltaTime);
            }
        }
        float angle;
        if(rb.velocity.y > 0)
        {
            angle = Mathf.Lerp(0, 75, rb.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            angle = Mathf.Lerp(0, -90, -rb.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        jumping = !jumping;
    }

    IEnumerator JumpCoolDown()
    {
        canJump = false;
        yield return new WaitForSeconds(coolDownTime);
        canJump = true;
    }

    public void StopBirdJump()
    {
        //Debug.Log("Bird Jump Stopped");
        canJump = false;
    }

    public IEnumerator GameOver()
    {
        isGameOver = true;
        Debug.Log("Before Couroutine: " + rb.velocity.y);
        yield return new WaitForSeconds(0.01f);
        Debug.Log("Couroutine: "+rb.velocity.y);
        rb.velocity = new Vector2(0, 0);
        //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
