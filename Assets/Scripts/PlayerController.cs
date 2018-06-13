using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {


    //General movement class taking care of moving player, calculating power cost and
    //sending refresh request to Interface Manager via ModifyPower and ModifyHP methods 

    public Transform playerTransform;
    Rigidbody2D rb2D;
    // movement
    public float speedGrounded;
    public float speedOffGround;
    public float jumpPower;
    public float jetPackPower;
    public float powerCost;

    [SerializeField]
    float slowDownRate;


    public float horizontalMove;
    float verticalMove;
    Vector2 movement;

    //ground Check
    public Transform groundCheck1;
    public Transform groundCheck2;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public bool grounded;

    //HP and power
    
    
    public float basePower;
    [SerializeField]
    public float power;

    public int baseHP;
    public int HP;

    public bool isAlive;
    [SerializeField]
    float pushBackModifyer;
    [SerializeField]
    GameObject animationParent;

    Vector2 playerVelocity;

    EmitParticle particleEmiter;

    bool isUsingJetpack;
    public float baseTimetoPowerRegeneration;
    float timeToPowerRegeneration;

    public float powerToRegenerate;

    AudioManager audioManager;

    bool isRunning = false;
    public bool isUsingPower;

    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        particleEmiter = GetComponent<EmitParticle>();
        power = basePower;
        HP = baseHP;
        SetInterfaceHP();
        PowerToInterfaceManager();
        isAlive = true;
        audioManager = FindObjectOfType<AudioManager>();

        //sisUsingPower = false;
	}

    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundCheck1.position, groundCheckRadius, groundLayer) ||
            Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, groundLayer))
        {
            grounded = true;
        }
        else grounded = false;
        
        Movement();
        
        if (isUsingJetpack == false)
        {
            audioManager.Stop("Jetpack");
            timeToPowerRegeneration += Time.deltaTime;
            if (timeToPowerRegeneration >= baseTimetoPowerRegeneration)
            {
                //regenerate power
                if(power < basePower)
                {
                    power = power + powerToRegenerate;
                    if (power > basePower)
                    {
                        power = basePower;
                    }
                    PowerToInterfaceManager();
                }
                
            }  
        }
        else
        {
            timeToPowerRegeneration = 0;
            audioManager.Play("Jetpack");
        }
        if (isRunning == false)
        {
            audioManager.Stop("Step");

        }
        else
        {
            audioManager.Play("Step");
        }


    }

    
    void Movement()
    {
        if(isAlive == true)
        {
            #region Horizontal input
            isUsingJetpack = false;

            
            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Jetpack") != 0 && power > 0 && isUsingPower == true)
            {
                isUsingJetpack = true;
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
                    isRunning = true;

                }
                else
                {
                    horizontalMove = Move(speedGrounded, "Horizontal");
                }
            }
            else
            {
                isRunning = false;
                horizontalMove = Input.GetAxis("Horizontal");
            }
               
            #endregion

            #region Vertical input 
            if (Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Jetpack") != 0 && power > 0 && isUsingPower == true)
            {
                print("Jetpack input detected");
                verticalMove = Move(powerCost, jetPackPower, "Vertical");
                isUsingJetpack = true;
                // if here set flag o using jetpack 
                //else set to not using jetpack, in update check if using jetpack, if not using jetpack for X seconds
                //start regeneratig power in update and trigger interface update
            }
            else if (Input.GetButtonDown("Jump"))
            {
                if (grounded)
                {
                    audioManager.Play("Jump");
                    verticalMove = jumpPower;
                }
                else
                {

                }
            }
            else
            {
               
                verticalMove = 0;
            }
            #endregion
        }

        movement = new Vector2(horizontalMove, verticalMove);
        rb2D.AddForce(movement);
        //rb2D.velocity = movement;
    }

    

    float Move(float powerCost, float powerModifier, string axis)
    {
        if (isUsingPower == true)
        {
            float move = Input.GetAxis(axis) * powerModifier;
            power = power - powerCost;
            PowerToInterfaceManager();
            return move;
        }
        else return 0;

    }
    float Move (float powerModifier, string axis)
    {
        float move = Input.GetAxis(axis) * powerModifier;
        return move;
    }
   
    public void ModifyHP (int HPModifier)
    {
        HP = HP + HPModifier;
        InterfaceManager.instance.HPChange(HP);

        if (HP <= 0)
        {
            HP = baseHP;
            //InterfaceManager.instance.HPChange(HP);
            print("PlayerKill");
            KillPlayer();
        }
    }
    public void ModifyPower(int modifyPower)
    {
        power += modifyPower;
        if (power > basePower)
        {
            power = basePower;
        }
        PowerToInterfaceManager();
    }

   
    void PowerToInterfaceManager()
    {
        if (InterfaceManager.instance.basePower == 0)
        {
            InterfaceManager.instance.basePower = basePower;
        }

        InterfaceManager.instance.PowerChange(power);
    }

    void KillPlayer()
    {
        //StartCoroutine(GameController.instance.PlayerRespown());
        StartCoroutine(particleEmiter.InstantiateParticle());
        SetInterfaceHP();
        StartCoroutine(GameController.instance.RestartLevel());
       

    }

    public void SlowPlayerDown()
    {
        //not working properly, as if player destroys the enemy and is already grounded this
        //does not slow him down, but pushes back with large force
        if (slowDownRate != 0)
        {
            playerVelocity = rb2D.velocity;
            rb2D.AddForce(new Vector2(rb2D.velocity.x * -slowDownRate, rb2D.velocity.y * -slowDownRate) * speedGrounded);
        }
    }
        

    //Not working properly
    public void PushPlayerBack(float enemyPositionX)
    {
        playerVelocity = rb2D.velocity;

        if (enemyPositionX > transform.position.x)
        {
            rb2D.AddForce(new Vector2((jumpPower) * -pushBackModifyer,
            (jumpPower) * pushBackModifyer));
        }
        else if (enemyPositionX < transform.position.x)
        {
            rb2D.AddForce(new Vector2(jumpPower * pushBackModifyer,
            jumpPower * pushBackModifyer));
        }
    }

    public void SetInterfaceHP()
    {
        InterfaceManager.instance.interfaceHP = baseHP;
    }

   
}
