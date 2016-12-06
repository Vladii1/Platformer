using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    Rigidbody2D rb2D;
    public float moveSpeed;
    bool isMovingRight;
    float scale;

    public Transform wallCheck;
    public LayerMask groundLayer;
    public float wallCheckRadius;
    public bool isHittingWall;

    public Transform edgeCheck;
    bool isOnEdge;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
	}

	
	// Update is called once per frame
	void Update () {
        isHittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, groundLayer);
        isOnEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, groundLayer);

        if (isHittingWall || !isOnEdge)
        {
            isMovingRight = !isMovingRight;
            
        }

        if (isMovingRight)
        {
            rb2D.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector3(-scale, scale, scale);
            
        }
        else
        {
            rb2D.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector3(scale, scale, scale);
        }

    }
}
