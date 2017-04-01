using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagMovement : MonoBehaviour {

    public float speed = 0.2f;
    bool facingRight = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {if (Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow)))
        {
            this.transform.Translate(-speed, 0, 0); // character moves left and right
            if (facingRight)
            {
                Flip();
            }
        }
        if (Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow)))
        {
            this.transform.Translate(speed, 0, 0); // character moves left and right
            if (!facingRight)
            {
                Flip();
            }
        }
    }

    // flips player sprite depending on direction moving
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
