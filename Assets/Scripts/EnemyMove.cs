using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    Rigidbody2D rb2D;
    public float moveSpeed;
    bool isMovingRight;

    float scale;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
        ChangeDirection();
	}

    void Update()
    {
        if (isMovingRight)
        {
            
            rb2D.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            rb2D.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector3(-scale, scale, scale);
        }
    }
    public void ChangeDirection ()
        {
            isMovingRight = !isMovingRight;
        }
    }

