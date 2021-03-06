﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 direction = Vector2.up;
    private Rigidbody2D rb2d;
    private CircleCollider2D cc2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Wall Bump Detection
        if (!openDirection(direction))
        {
            if (canChangeDirection())
            {
                changeDirection();
            }
            else if (rb2d.velocity.magnitude < speed)
            {
                changeDirectionAtRandom();
            }
        }
        // Come Across an Intersection
        else if (canChangeDirection() && Time.time > changeDirectionTime)
        {
            changeDirectionAtRandom();
        }

        // stuck on a non-wall
        else if (rb2d.velocity.magnitude < speed)
        {
            changeDirectionAtRandom();
        }

        // Rotate Eyes
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if ( t != transform)
            {
                t.up = direction;
            }
            
        }

        // Move
        rb2d.velocity = direction * speed;
        
        if (rb2d.velocity.x == 0)
        {
            transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
        }    
        if (rb2d.velocity.y == 0)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
        }
    }

    private float changeDirectionTime; //the soonest time he can change direction

    private bool canChangeDirection()
    {
        Vector2 perpRight = Utility.PerpendicularRight(direction);
        bool openRight = openDirection(perpRight);
        Vector2 perpLeft = Utility.PerpendicularLeft(direction);
        bool openLeft = openDirection(perpLeft);
        return openLeft || openRight;
    }

    private void changeDirectionAtRandom()
    {
        changeDirectionTime = Time.time + 1;
        if (Random.Range(0, 3) == 0 )
        {
            changeDirection();
        }
    }

    private void changeDirection()
    {
        changeDirectionTime = Time.time + 1;
        Vector2 perpRight = Utility.PerpendicularRight(direction);
        bool openRight = openDirection(perpRight);
        Vector2 perpLeft = Utility.PerpendicularLeft(direction);
        bool openLeft = openDirection(perpLeft);
        if (openRight || openLeft)
        {
            int choce = Random.Range(0, 2);
            if (!openLeft || (choce == 0 && openRight))
            {
                direction = perpRight;
            }
            else
            {
                direction = perpLeft;
            }
        }
        
        else if(!openLeft && !openRight)
        {
            direction = -direction;
        }
    }

    private bool openDirection(Vector2 direction)
    {
        RaycastHit2D[] rch2ds = new RaycastHit2D[10];
        cc2d.Cast(direction, rch2ds, 1f, true);
        foreach (RaycastHit2D rch2d in rch2ds)
        {
            if (rch2d && rch2d.collider.gameObject.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.transform.position = Vector2.zero;
        }
    }
}
