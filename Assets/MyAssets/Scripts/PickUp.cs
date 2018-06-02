using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
    public int HP;
    public int Power; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    //void OnCollisionEnter(Collision2D collision)
    //{
    //    print("PICK UP HIT");
    //    if (collision.gameObject.tag == "Player") //&& other.GetComponent<CapsuleCollider2D>().isTrigger == true)
    //    {
    //        print("PICK UP HIT");
    //        if (HP > 0)
    //        {
       
    //            collision.gameObject.GetComponent<PlayerController>().ModifyHP(HP);
    //            Destroy(gameObject);
    //        }
    //        else if (Power > 0)
    //        {
    //            collision.gameObject.GetComponent<PlayerController>().ModifyPower(Power);
    //            Destroy(gameObject);
    //        }
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //&& other.GetComponent<CapsuleCollider2D>().isTrigger == true)
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            print("PICK UP HIT");
            if (HP > 0)
            {
                if(playerController.baseHP > playerController.HP)
                {
                    playerController.ModifyHP(HP);
                    Destroy(gameObject);
                }

            }
            else if (Power > 0)
            {
                if (playerController.basePower > playerController.power)
                {
                    playerController.ModifyPower(Power);
                    Destroy(gameObject);
                }
               
            }
        }
    }
}

