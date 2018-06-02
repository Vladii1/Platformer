using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackTutorial : MonoBehaviour
{
    public GameObject display;
    bool infoDisplayed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (infoDisplayed == true)
        {
            if (Input.GetAxisRaw("Jetpack") != 0)
            {
                Destroy(display);
            }
        }
    }
   public void Display()
    {
        display.SetActive(true);
        infoDisplayed = true;
    }
}