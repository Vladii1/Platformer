using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    Animator anim;
    public Animator animMouth;
    PlayerController player;
    Transform playerTransform;

	void Start () {
        anim = GetComponent<Animator>();
        //animMouth = GetComponentInChildren<Animator>();
        player = GetComponentInParent<PlayerController>();
        playerTransform = GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        if (player.horizontalMove != 0)
        {
            anim.SetBool("isWalking", true);
            if (player.horizontalMove > 0) playerTransform.localScale = new Vector3(1, 1, 1);
            else if (player.horizontalMove < 0) playerTransform.localScale = new Vector3(-1, 1, 1);
        }
        else anim.SetBool("isWalking", false);
       
        if (Input.GetKeyDown(KeyCode.Space)) anim.SetTrigger("jumpDown");
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetTrigger("jumpUp");
            animMouth.SetTrigger("jump");
        }
	}
}
