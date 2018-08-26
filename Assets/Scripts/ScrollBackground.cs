using System.Collections;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public float speed = 0.4f;
    private bool canScroll = true;

	void Update () {
        if (canScroll)
        {
            if (transform.position.x > -20)
            {
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            }
            else
            {
                transform.Translate(new Vector2(40, 0));
            }
        }
	}

    public void StopScrolling()
    {
        canScroll = false;
    }
}
