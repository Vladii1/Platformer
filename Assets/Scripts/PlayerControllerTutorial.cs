using UnityEngine;
using System.Collections;

public class PlayerControllerTutorial : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	Rigidbody2D rb2D;
    public Transform groundCheck;
    public LayerMask groundLayer;
    float groundCheckRadius;
    bool grounded;
    bool doubleJumped; 

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
       
	}
	

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

	// Update is called once per frame
	void Update () {
        if (grounded) doubleJumped = false;

		if (Input.GetKeyDown(KeyCode.Space) && grounded || Input.GetKeyDown(KeyCode.Space) && !doubleJumped)
		{
            doubleJumped = true;
            Jump();
		}
        
		if (Input.GetKey (KeyCode.D)) 
		{
			rb2D.velocity = new Vector2 (speed, rb2D.velocity.y);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			rb2D.velocity = new Vector2 (-speed, rb2D.velocity.y);
		}

		/*
		if (Input.GetAxis ("Horizontal")!=0|| Input.GetAxis("Vertical")!=0) 
		{
			rb2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, 0);
			rb2D.velocity = new Vector2 (rb2D.velocity.x, Input.GetAxisRaw ("Vertical") * jumpHeight);
		}
	*/
	}

    void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
    }
}
