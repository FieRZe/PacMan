using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb2d;

	public float speed; // the speedpacman can travel
    // Start is called before the first frame update

	private Vector2 direction; // the direction pacman is going

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
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
}
