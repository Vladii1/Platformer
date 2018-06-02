using UnityEngine;
using System.Collections;

public class EnemyMoveLeftToRight : MonoBehaviour {

    Rigidbody2D rb2D;
    public float moveSpeed;
    public bool isMovingRight;

    float scale;

    // Use this for initialization
    void Start()
    {
        moveSpeed = 1500;
        rb2D = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;

    }

    void FixedUpdate()
    {
        if (isMovingRight)
        {
            rb2D.velocity = new Vector2(moveSpeed, 0) * Time.deltaTime;
            //rb2D.AddForce(new Vector2(moveSpeed, 0) * Time.deltaTime);
            transform.localScale = new Vector3(-scale, scale, scale);
        }
        else
        {
            rb2D.velocity = new Vector2(-moveSpeed, 0) * Time.deltaTime;
            //rb2D.AddForce(new Vector2(-moveSpeed, 0) * Time.deltaTime);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void ChangeDirection (bool movingRight)
    {
        if (isMovingRight == true)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else if (isMovingRight == false)
        {
            transform.localScale = new Vector3(-scale, scale, scale);
        }
    }
    public void ChangeDirection()
    {
        isMovingRight = !isMovingRight;
    }
}

