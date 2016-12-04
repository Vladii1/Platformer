using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;
    // movement
    public float speedGrounded;
    public float speedOffGround;
    public float jumpPower;
    public float jetPackPowerUp;
    public float jetPackPowerDown;

    float horizontalMove;
    float verticalMove;
    Vector2 movement;

    //ground Check
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    bool grounded;

    //HP and power
    public int power = 100;
    public int HP = 100;


    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        HPToInterfaceManager();
        PowerToInterfaceManager();
        
	}
	
	
	void Update () {

        
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Movement();
    }

    void Movement()
    {
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
                if (Input.GetAxis("Vertical") > 0)
                {
                    verticalMove = Input.GetAxis("Vertical") * jetPackPowerUp;
                    power--;
                    PowerToInterfaceManager();
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    verticalMove = Input.GetAxis("Vertical") * jetPackPowerDown;
                    power--;
                    PowerToInterfaceManager();
                }
            }
        }
        else verticalMove = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalMove, verticalMove);
        rb2D.AddForce(movement);
    }

    public void ModifyPower(int modifyPower)
    {
        power += modifyPower;
        PowerToInterfaceManager();
    }
    public void ModifyHP (int modifyHP)
    {
        HP += modifyHP;
        HPToInterfaceManager();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        print(coll.relativeVelocity.y);
    }
    void HPToInterfaceManager()
    {
        InterfaceManager.instance.hpText.text = HP.ToString();
    }
    void PowerToInterfaceManager()
    {
        InterfaceManager.instance.powerText.text = power.ToString();
    }
}
