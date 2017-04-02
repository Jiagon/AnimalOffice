using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagMovement : MonoBehaviour {

    public float speed = 0.2f;
    bool facingRight = true;
    bool frozen = false;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {

            if ((Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow))) && this.transform.position.x > -14) // position > -14 prevents player moving too far left
            {
                this.transform.Translate(-speed, 0, 0); // character moves left
                if (facingRight)
                {
                    this.transform.Translate(-speed, 0, 0); // character moves left and right
                    if (facingRight)
                    {
                        Flip();
                    }
                }
            }
            if ((Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow))) && this.transform.position.x < 120) // position < 120 prevents player moving too far right
            {
                this.transform.Translate(speed, 0, 0); // character moves right
                if (!facingRight)
                {
                    this.transform.Translate(speed, 0, 0); // character moves left and right
                    if (!facingRight)
                    {
                        Flip();
                    }
                }

                if (this.transform.position.x > 10 && this.transform.position.x < 15)
                {
                    this.transform.Translate(48, 0, 0);
                    Flip();
                }

                if (this.transform.position.x > 60 && this.transform.position.x < 65)
                {
                    this.transform.Translate(-55, 0, 0);
                    Flip();
                }

                if (this.transform.position.x > 40 && this.transform.position.x < 45)
                {
                    this.transform.Translate(55, 0, 0);
                    Flip();
                }

                if (this.transform.position.x > 92 && this.transform.position.x < 97)
                {
                    this.transform.Translate(-50, 0, 0);
                    Flip();
                }
                if (this.transform.position.x > 12 && this.transform.position.x < 16) //floor 1 -> floor 2
                {
                    this.transform.Translate(51, 0, 0);
                    Flip();
                }

                if (this.transform.position.x > 65 && this.transform.position.x < 69) // floor 2 -> floor 1
                {
                    this.transform.Translate(-55, 0, 0);
                    Flip();
                }

                if (this.transform.position.x > 37 && this.transform.position.x < 41) // floor 2 -> floor 3
                {
                    this.transform.Translate(56, 0, 0);
                    Flip();
                }

                if (this.transform.position.x > 89 && this.transform.position.x < 93) // floor 3 -> floor 2
                {
                    this.transform.Translate(-49, 0, 0);
                    Flip();
                }
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

    public void setFrozen(bool value)
    {
        frozen = value;
    }
}