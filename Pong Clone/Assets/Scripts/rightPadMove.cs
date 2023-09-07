using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightPadMove : MonoBehaviour
{
    //variables for the code
    public float speed = 10f;
    public float yBorder = 4.5f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //declare value of the variable
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = rb2d.velocity;    //create and declare variable for velocity

        //control the paddle
         if (Input.GetKey(KeyCode.O) && transform.position.y < yBorder) { //when O is pressed and still inside edge
            velocity.y = speed;      //move the speed up
            }
            else if (Input.GetKey(KeyCode.L) && transform.position.y > -yBorder){ //when L is pressed and still inside edge
                velocity.y = -speed;           //move the speed down
                Debug.Log ("L");
            }
            else{                    //other wise
                velocity.y = 0;      //dont move
            }
            rb2d.velocity = velocity;
    }
}
