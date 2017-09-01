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
    float speed1;
    [SerializeField]
    float speed2;
    [SerializeField]
    float speed3;

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
        print(color1);
        //color1 = new Color(255, 215, 49, 1);

    }

    // Update is called once per frame
    void Update()
    {
        #region Jetpack direction
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
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
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                transform.rotation = Quaternion.Euler(45, 90, 90);
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                transform.rotation = Quaternion.Euler(315, 90, 90);
                particle.Play();
            }
            else
            {
                transform.rotation = Quaternion.Euler(360, 90, 90);
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                transform.rotation = Quaternion.Euler(90, 90, 90);
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                transform.rotation = Quaternion.Euler(270, 90, 90);
            }
        }
        #endregion

        #region Jetpack emission 

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                
                emissionRate.rateOverTime = 20;
            }
            else
            {
                emissionRate.rateOverTime = 3;
            }
        }
        else if (rb2D.velocity.x == 0 || rb2D.velocity.y == 0)
        {
            emissionRate.rateOverTime = 0;
            // particle.emission.rateOverTime = 0;
        }
        #endregion

        #region Jetpack color
        
        if (Mathf.Abs(rb2D.velocity.x) < speed1 || Mathf.Abs(rb2D.velocity.y) < speed1)
        {
            //particleMain.startColor = Color.HSVToRGB(color1.);
            //particle.startColor = color1;
            particleMain.startColor = new Color(color1.r, color1.g, color1.b);

            
        }
        if (Mathf.Abs(rb2D.velocity.x) >= speed1|| Mathf.Abs(rb2D.velocity.y) >= speed1)
        {
            particleMain.startColor = new Color (color2.r, color2.g, color2.b);
            //print(Mathf.Abs(rb2D.velocity.x) + ", " + Mathf.Abs(rb2D.velocity.y));


        }
        if (Mathf.Abs(rb2D.velocity.x) >= speed2 || Mathf.Abs(rb2D.velocity.y) >= speed2)
        {
            particleMain.startColor = new Color(color3.r, color3.g, color3.b);

        }

       // print(Mathf.Abs( rb2D.velocity.x) +", " + Mathf.Abs(rb2D.velocity.y));
        #endregion
    }
}
