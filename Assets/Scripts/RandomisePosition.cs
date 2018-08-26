using System.Collections;
using UnityEngine;

public class RandomisePosition : MonoBehaviour {

    //Rigidbody2D rb;
    //ScrollObjects sc;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("UpperPipe"))
        {
            //Debug.Log("Before: " + collider.gameObject.transform.position);
            collider.gameObject.transform.position = new Vector3(collider.gameObject.transform.position.x, Random.Range(5f, 8f), 0);
            //Debug.Log("After: " + collider.gameObject.transform.position);

            //rb = collider.gameObject.GetComponent<Rigidbody2D>();
            //rb.MovePosition(rb.position + Vector2.up);

            //sc = collider.gameObject.GetComponent<ScrollObjects>();
            //sc.ChangePosition();
        }
    }
}
