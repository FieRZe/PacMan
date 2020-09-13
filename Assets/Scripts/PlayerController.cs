using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb2d;

	public float speed; // the speedpacman can travel
    // Start is called before the first frame update
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
            
            rb2d.velocity = Vector2.left * speed;
        }
        // moving right
        if (Input.GetAxis("Horizontal") > 0 )
        {
            
            rb2d.velocity = Vector2.right * speed;
        }
        // moving down
        if (Input.GetAxis("Vertical") < 0 )
        {
            
            rb2d.velocity = Vector2.down * speed;
        }
        // moving up
        if (Input.GetAxis("Vertical") > 0 )
        {
            
            rb2d.velocity = Vector2.up * speed;
        }
        
        
    }
}
