using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;

    public float speedGrounded;
    public float speedOffGround;
    public float jumpPower;
    public float jetPackPowerUp;
    public float jetPackPowerDown;

    float horizontalMove;
    float verticalMove;
    Vector2 movement;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    bool grounded;

    public float power;



    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

       
	}

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (grounded)
            {
                horizontalMove = Input.GetAxis("Horizontal") * speedGrounded;
            }
            else
            {
                horizontalMove = Input.GetAxis("Horizontal") * speedOffGround;
            }
        }
        else horizontalMove = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") != 0)
        {
            if (grounded)
            {
                verticalMove = Input.GetAxisRaw("Vertical") * jumpPower;
            }
            else
            {
                if(Input.GetAxis("Vertical") > 0)
                {
                    verticalMove = Input.GetAxis("Vertical") * jetPackPowerUp;
                    power--;
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    verticalMove = Input.GetAxis("Vertical") * jetPackPowerDown;
                    power--;
                }
            }
        }
        else verticalMove = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalMove, verticalMove);
        //print(rb2D.velocity.y);
        rb2D.AddForce(movement);
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    coll.gameObject.
    //    print(rb.velocity.y);
    //}
}
