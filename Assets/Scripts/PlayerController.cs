using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2D;
    // movement
    public float speedGrounded;
    public float speedOffGround;
    public float jumpPower;
    public float jetPackPower;
    public float powerCost;


    public float horizontalMove;
    float verticalMove;
    Vector2 movement;

    //ground Check
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public bool grounded;

    //HP and power
    
    [SerializeField]
    float basePower;
    float power;
    [SerializeField]
    float baseHP;
    float HP;

    public bool isAlive;

    public float pushBackModifyer = 0.5f;


    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        power = basePower;
        HP = baseHP;
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
           
            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetKey(KeyCode.LeftShift))
            {
                if (grounded)
                {
                    horizontalMove = Move(powerCost, jetPackPower,  "Horizontal");
                }
                else
                {
                    horizontalMove = Move(powerCost, jetPackPower, "Horizontal");
                }
            }
            else if (Input.GetAxisRaw("Horizontal") != 0)
                {
                if (grounded)
                {
                    horizontalMove = Move(speedGrounded, "Horizontal");

                }
                else
                {
                    horizontalMove = Move(speedGrounded, "Horizontal");
                }
            }
            else horizontalMove = Input.GetAxis("Horizontal");



            if (Input.GetAxisRaw("Vertical") != 0 && Input.GetKey(KeyCode.LeftShift))
            {
                if (grounded)
                {

                    verticalMove = Move(powerCost, jetPackPower, "Vertical");
                }
                else
                {
                    verticalMove = Move(powerCost, jetPackPower, "Vertical");
                }

            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (grounded)
                {
                    verticalMove = jumpPower;
                }
                else
                {

                }
            }
            else verticalMove = Input.GetAxis("Vertical");
        }

        movement = new Vector2(horizontalMove, verticalMove);
        rb2D.AddForce(movement);
    }

    public void ModifyPower(int modifyPower)
    {
        power += modifyPower;
        PowerToInterfaceManager();
    }
    float Move(float powerCost, float powerModifier, string axis)
    {
        float move = Input.GetAxis(axis) * powerModifier;
        power = power - powerCost;
        PowerToInterfaceManager();
        return move;
    }
    float Move (float powerModifier, string axis)
    {
        float move = Input.GetAxis(axis) * powerModifier;
        return move;
    }
   
    public void ModifyHP (int modifyHP)
    {
        HP += modifyHP;
        HPToInterfaceManager();

        if (HP <= 0)
        {
            KillPlayer();
        }
    }
    void KillPlayer()
    {
        StartCoroutine(GameController.instance.PlayerRespown());
        StartCoroutine(GetComponent<EmitParticle>().InstantiateParticle());
    }

    public void SlowPlayerDown()
    {
        Vector2 playerVelocity;

        playerVelocity = rb2D.velocity;
        rb2D.velocity.Set(playerVelocity.x * 0.5f, playerVelocity.y *0.5f);
        //playerVelocity.x = playerVelocity.x - speedDecrease;
        //playerVelocity.y = playerVelocity.y - speedDecrease; 
    }

    public void PushPlayerBack()
    {
        Vector2 playerVelocity;
        playerVelocity = rb2D.velocity;

        print(playerVelocity);
        rb2D.AddForce(new Vector2((rb2D.velocity.x + jumpPower),(rb2D.velocity.y + jumpPower)));

        //rb2D.velocity.Set(10000, 10000);
        //rb2D.velocity.Set(playerVelocity.x * -pushBackModifyer, playerVelocity.y * -pushBackModifyer);
        //playerVelocity.x = playerVelocity.x * -pushBackModifyer;
        //playerVelocity.y = playerVelocity.y * -pushBackModifyer;
        print(playerVelocity);

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
