using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb2d;
    Animator animator;

	public float speed; // the speedpacman can travel
    // Start is called before the first frame update
    public int score = 0; // the score
    public Text scoreText; // the text UI Component that shows the score


    private Vector2 direction; // the direction pacman is going

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("currentSpeed", rb2d.velocity.magnitude); 
    	// moving left
        if (Input.GetAxis("Horizontal") < 0 ) 
        {
            direction = Vector2.left;
        }
        // moving right
        if (Input.GetAxis("Horizontal") > 0 )
        {
            direction = Vector2.right;
        }
        // moving down
        if (Input.GetAxis("Vertical") < 0 )
        {
            
            direction = Vector2.down;
        }
        // moving up
        if (Input.GetAxis("Vertical") > 0 )
        {
            
            direction = Vector2.up;
        }
        
        // To avoid decreasing speed when you touch boxcolliders we need to set our speed to constant
        // no matter what

        rb2d.velocity = direction * speed; // but in this case we need to remember what direction is going
		transform.up = direction; 


		if (rb2d.velocity.x == 0) // meaning that he's going up and down by 'y'
		{
			// that won't work in some games but in this game it'll work
			transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y );

		}
        
        if (rb2d.velocity.y == 0) // meaning that he's going up and down by 'y'
		{
			// that won't work in some games but in this game it'll work
			transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));

		}
    }

    public void addPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "" + score;
    }
}
