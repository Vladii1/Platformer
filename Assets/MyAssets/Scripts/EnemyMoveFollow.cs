using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveFollow : MonoBehaviour {
   
    Rigidbody2D rb2D;
    float scale;
    // Use this for initialization
    void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
    }

    public void Move (float directionX, float directionY, float moveSpeed)
    {
        rb2D.velocity = new Vector2(directionX * moveSpeed, directionY * moveSpeed) * Time.deltaTime;
        //transform.Translate(new Vector3(directionX, directionY, 0));
        //rb2D.AddForce((direction * moveSpeed)* Time.deltaTime);
        CheckDirection(directionX);
    }

    public void Move(float directionX, float moveSpeed)
    {
        rb2D.velocity = new Vector2(directionX * moveSpeed, 0) * Time.deltaTime;
        
    }
    public void CheckDirection(float targetPositionX)
    {
        if ( targetPositionX > transform.position.x)
        {
            transform.localScale = new Vector3(-scale, scale, scale);
        }
        else if (targetPositionX < transform.position.x)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {

        }
    }
}
