using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEnabler : MonoBehaviour {

    public JetpackTutorial jetpackTutorial;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().isUsingPower = true;
            collision.GetComponentInChildren<JetpackController>().isUsingPower = true;
            InterfaceManager.instance.SwitchPower(true);
            jetpackTutorial.Display();
            Destroy(this.gameObject);
        }
        
    }
}
