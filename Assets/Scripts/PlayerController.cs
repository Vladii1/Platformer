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

            if (Input.GetKeyUp(KeyCode.Space) && grounded)
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
        rb2D.AddForce(new Vector2(1000, 1000));

        rb2D.velocity.Set(10000, 10000);
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
