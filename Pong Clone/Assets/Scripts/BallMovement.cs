using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    //variables for the code
    public float xSpeed;            //variable for horizontal speed
    public float ySpeed;            //variable for vertical speed
    
    public bool xMove =  true;      //variable for horizaontal state
    public bool yMove = true;       //variable for vertical state

    float xBorder = 7.5f;           //variable for horizontal border
    public float yBorder = 4.5f;    //variable for vertical border

    public int playerOneScore;
    public int playerTwoScore;
    public Text scoreTextP1;
    public Text scoreTextP2;

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0.125f;    //declare value of horizontal speed
        ySpeed = 0.125f;    //declare value of vertical speed        
    }

    // Update is called once per frame
    void Update()
    {
        //control vertical move
        if (yMove == true){ // if vertical move true
            transform.position = new Vector2(transform.position.x, transform.position.y + ySpeed);  //move up
        }
        else {
            transform.position = new Vector2(transform.position.x, transform.position.y - ySpeed);  //move down
        }
        if (transform.position.y >= yBorder){       //if ball gets to the top edge
            yMove = false;                          //bounce down
        }
        if (transform.position.y <= -yBorder){      //if ball get to the floor edge
            yMove = true;                           ///bounce up
       }

        //control horizontal movement
        if (xMove == true){     //if vertical move true
            transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y);  //move right
        }
        else {
            transform.position = new Vector2(transform.position.x - xSpeed, transform.position.y);  //move left
        }
        if (transform.position.x >= xBorder){       //if ball get to the right edge
            // xMove = false;                          //bounce left
            transform.position = Vector2.zero;   //reset ball
            playerOneScore ++;

        }
        if (transform.position.x <= -xBorder){      //if ball get to the left edge
            //  xMove = true;                          //bounce right
            transform.position = Vector2.zero;   //reset ball
            playerTwoScore ++;
        }
        
        scoreTextP1.text = playerOneScore.ToString();
        scoreTextP2.text = playerTwoScore.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision){  //when collision happend

       if (collision.collider.CompareTag ("Player")){ //if the other object is the player
        Debug.Log("hit");                                //tell me it hit
        
        // bouce off the other direction
        if (xMove ==  true){                  
            xMove = false;
        }
        else if (xMove == false){
            xMove = true;
        }
    }
    }
    
}
