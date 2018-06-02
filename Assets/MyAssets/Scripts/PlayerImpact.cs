using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : MonoBehaviour {

    AudioManager audioManager;
	// Use this for initialization
	void Start () {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    //collision.otherCollider.gameObject.layer == 8 &&
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if( collision.relativeVelocity.y > 20)
        {
            audioManager.Play("Impact");
        }
    }
}
