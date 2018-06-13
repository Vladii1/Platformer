using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : MonoBehaviour {

    Rigidbody2D rb2D;
    PlayerController playerController;
    ParticleSystem particle;
    ParticleSystem.MainModule particleMain;
    ParticleSystem.EmissionModule emissionRate;
    Renderer renderer;
    int sortingLayer;

    [SerializeField]
    Color color1;
    [SerializeField]
    Color color2;
    [SerializeField]
    Color color3;
    [SerializeField]
    Color color4;

    [SerializeField]
    float speed1;
    [SerializeField]
    float speed2;
    [SerializeField]
    float speed3;

    CameraShake camShake;
    [SerializeField]
    float shakeAmount;
    [SerializeField]
    float shakeLength;

    [SerializeField]
    int emissionMovement = 3;
    [SerializeField]
    int emissionJetpatck = 20;
    int emissionStop = 0;

    public bool isUsingPower; 
    //AudioManager audioManager;
    //bool isJetpackPlaying = false;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        rb2D = GetComponentInParent<Rigidbody2D>();
        playerController = GetComponentInParent<PlayerController>();
        emissionRate = particle.emission;
        particleMain = particle.main;
        renderer = particle.GetComponent<Renderer>();
        renderer.sortingLayerName = "Player";
    }

    void Start()
    {
        camShake = GameController.instance.gameObject.GetComponent<CameraShake>();

        //audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // print(rb2D.velocity);

        if (Input.GetAxisRaw("Jetpack") != 0)
        {

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                JetpackOn();

                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    transform.rotation = Quaternion.Euler(135, 90, 90);
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    transform.rotation = Quaternion.Euler(215, 90, 90);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(180, 90, 90);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                JetpackOn();
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    transform.rotation = Quaternion.Euler(45, 90, 90);
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    transform.rotation = Quaternion.Euler(315, 90, 90);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(360, 90, 90);
                }
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                JetpackOn();
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    transform.rotation = Quaternion.Euler(90, 90, 90);
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    transform.rotation = Quaternion.Euler(270, 90, 90);
                }
            }
            else TurnOffEmission();

        }
        else if (Input.GetAxisRaw("Horizontal") != 0 && playerController.grounded == true && !Input.GetKey(KeyCode.LeftShift))
        {
            emissionRate.rateOverTime = emissionMovement;
            //audioManager.Stop("Jetpack");
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.rotation = Quaternion.Euler(360, 90, 90);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(180, 90, 90);
            }
        }
        else if (rb2D.velocity.x != 0 || rb2D.velocity.y != 0 /* && playerController.grounded */ )
        {
            //print(rb2D.velocity);
            emissionRate.rateOverTime = emissionMovement;
           // audioManager.Stop("Jetpack");
            if (rb2D.velocity.x > 0)
            {
                if (rb2D.velocity.y > 0)
                {
                    transform.rotation = Quaternion.Euler(135, 90, 90);
                }
                else if (rb2D.velocity.y < 0)
                {
                    transform.rotation = Quaternion.Euler(215, 90, 90);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(180, 90, 90);
                }
            }
            else if (rb2D.velocity.x < 0)
            {
                if (rb2D.velocity.y > 0)
                {
                    transform.rotation = Quaternion.Euler(45, 90, 90);
                }
                else if (rb2D.velocity.y < 0)
                {
                    transform.rotation = Quaternion.Euler(315, 90, 90);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(360, 90, 90);
                }
            }
            else if (rb2D.velocity.y != 0)
            {
                if (rb2D.velocity.y > 0)
                {
                    transform.rotation = Quaternion.Euler(90, 90, 90);
                }
                else if (rb2D.velocity.y < 0)
                {
                    transform.rotation = Quaternion.Euler(270, 90, 90);
                }
            }
            else if (rb2D.velocity.x == 0 || rb2D.velocity.y < -0.1) transform.rotation = Quaternion.Euler(90, 90, 90);
        }
        else if (rb2D.velocity.x == 0 && rb2D.velocity.y == 0)
        {
            TurnOffEmission();
        }
        else TurnOffEmission();

        #region Jetpack color

        if (Mathf.Abs(rb2D.velocity.x) < speed1 || Mathf.Abs(rb2D.velocity.y) < speed1)
        {
            //particleMain.startColor = Color.HSVToRGB(color1.);
            //particle.startColor = color1;
            particleMain.startColor = new Color(color1.r, color1.g, color1.b);


        }
        if (Mathf.Abs(rb2D.velocity.x) >= speed1 || Mathf.Abs(rb2D.velocity.y) >= speed1)
        {
            particleMain.startColor = new Color(color2.r, color2.g, color2.b);
            //print(Mathf.Abs(rb2D.velocity.x) + ", " + Mathf.Abs(rb2D.velocity.y));


        }
        if (Mathf.Abs(rb2D.velocity.x) >= speed2 || Mathf.Abs(rb2D.velocity.y) >= speed2)
        {
            particleMain.startColor = new Color(color3.r, color3.g, color3.b);
            //print(Mathf.Abs(rb2D.velocity.x) + ", " + Mathf.Abs(rb2D.velocity.y));
        }
        if (Mathf.Abs(rb2D.velocity.x) >= speed3 || Mathf.Abs(rb2D.velocity.y) >= speed3)
        { 
            particleMain.startColor = new Color(color4.r, color4.g, color4.b);
            //print(Mathf.Abs(rb2D.velocity.x) + ", " + Mathf.Abs(rb2D.velocity.y));
        }


        // print(Mathf.Abs( rb2D.velocity.x) +", " + Mathf.Abs(rb2D.velocity.y));
        #endregion
    }

    public void TurnOffEmission()
    {
        emissionRate.rateOverTime = emissionStop;
        //audioManager.Stop("Jetpack");
        //isJetpackPlaying = false;
        //print("stop sound executed");
    }

    void JetpackOn()
    {
        if (isUsingPower == true && playerController.power > 0)
        {
            emissionRate.rateOverTime = emissionJetpatck;
            camShake.ShakeTheCamera(shakeAmount, shakeLength);
        }
        else return;

        //if (isJetpackPlaying == false)
        //{
        //    audioManager.Play("Jetpack");
        //    isJetpackPlaying = true;
        //}
        
    }


}
