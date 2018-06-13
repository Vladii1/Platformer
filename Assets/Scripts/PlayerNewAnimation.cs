using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNewAnimation : MonoBehaviour {
    Animator anim;
    //public Animator animMouth;
    PlayerController player;
    Transform playerTransform;

	void Start () {
        anim = GetComponent<Animator>();
        player = GetComponentInParent<PlayerController>();
        playerTransform = GetComponentInParent<Transform>();
	}

    void FixedUpdate()
    {
        if (player.horizontalMove != 0)
        {
            anim.SetBool("isWalking", true);
            if (player.horizontalMove > 0) playerTransform.localScale = new Vector3(10, 10, 1);
            else if (player.horizontalMove < 0) playerTransform.localScale = new Vector3(-10, 10, 1);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            if (player.horizontalMove > 0) playerTransform.localScale = new Vector3(10, 10, 1);
            else if (player.horizontalMove < 0) playerTransform.localScale = new Vector3(-10, 10, 1);
        }
    }
}
