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
    public float powerCostUp;
    public float powerCostDown;
    

    float horizontalMove;
    float verticalMove;
    Vector2 movement;

    //ground Check
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public bool grounded;

    //HP and power
    public float power = 100;
    public int HP = 100;

    public bool isAlive; 


    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        HPToInterfaceManager();
        PowerToInterfaceManager();
        isAlive = true;
	}
	
	
	void Update () {

        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Movement();
    }

    void Movement()
    {
        if(isAlive == true)
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
            else horizontalMove = Input.GetAxis("Horizontal"); // what does it do?



            if (Input.GetAxis("Vertical") > 0 && power > 0)
            {
                UsePower(powerCostUp);
            }
            else if (Input.GetAxis("Vertical") < 0 && power > 0)
            {
                UsePower(powerCostDown);
            }
            else verticalMove = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                verticalMove = jumpPower;
            }
       } 
        movement = new Vector2(horizontalMove, verticalMove);
        rb2D.AddForce(movement);
    }

    public void ModifyPower(int modifyPower)
    {
        power += modifyPower;
        PowerToInterfaceManager();
    }
    void UsePower (float powerCost)
    {
        verticalMove = Input.GetAxis("Vertical") * jetPackPowerDown;
        power = power - powerCost;
        PowerToInterfaceManager();
    }
    public void ModifyHP (int modifyHP)
    {
        HP += modifyHP;
        HPToInterfaceManager();
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    print(rb2D.velocity.y);
    //}
    void HPToInterfaceManager()
    {
        InterfaceManager.instance.hpText.text = HP.ToString();
    }
    void PowerToInterfaceManager()
    {
        InterfaceManager.instance.powerText.text = power.ToString();
    }
}
