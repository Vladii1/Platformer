using UnityEngine;
using System.Collections;

class ImpactEnemy : MonoBehaviour {
    [SerializeField]
    private float velocityThresholdEnemy;

    private void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Contact(collision);

        if (collision.gameObject.tag == "Player")
        {
            if (collision.rigidbody.velocity.x <= -velocityThresholdEnemy || 
                collision.rigidbody.velocity.y <= -velocityThresholdEnemy ||
                collision.rigidbody.velocity.x >= velocityThresholdEnemy ||
                collision.rigidbody.velocity.y >= velocityThresholdEnemy)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                if (transform.parent != null) Destroy(transform.parent.gameObject);
                collision.gameObject.GetComponent<PlayerController>().SlowPlayerDown();
                
            }
            else
            {
                collision.gameObject.GetComponent<PlayerController>().ModifyHP(-10);
                collision.gameObject.GetComponent<PlayerController>().PushPlayerBack(transform.position.x);
            }
        }
        else
        {
            return;
        }
    }
    


    //OnCollisionEnter2D
    void Contact (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //collision.gameObject.GetComponent<PlayerController>().isAlive == true)
        {
            print(Mathf.Abs(collision.rigidbody.velocity.x) + ", " + Mathf.Abs(collision.rigidbody.velocity.y));
            //print(collision);
            print("Player and Enemy Collision");
            


            if (collision.rigidbody.velocity.y >= velocityThresholdEnemy ||
                collision.rigidbody.velocity.y <= -velocityThresholdEnemy ||
                collision.relativeVelocity.x >= velocityThresholdEnemy ||
                  collision.relativeVelocity.x <= -velocityThresholdEnemy)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                if (transform.parent != null) Destroy(transform.parent.gameObject);
                collision.gameObject.GetComponent<PlayerController>().SlowPlayerDown();
            }
            //if (collision.rigidbody.velocity.y >= velocityThreshold ||
            //    collision.rigidbody.velocity.y <= velocityThreshold ||
            //    collision.relativeVelocity.x >= velocityThreshold ||
            //      collision.relativeVelocity.x <= velocityThreshold)
            else 
            {
                collision.gameObject.GetComponent<PlayerController>().ModifyHP(-10);
                collision.gameObject.GetComponent<PlayerController>().PushPlayerBack(transform.position.x);

            }
        }
    }
   

   


}
