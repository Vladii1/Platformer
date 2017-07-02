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
        Contact(collision, velocityThresholdEnemy);

    }
    


    //OnCollisionEnter2D
    void Contact (Collision2D collision, float velocityThreshold)
    {
        if (collision.gameObject.tag == "Player") //collision.gameObject.GetComponent<PlayerController>().isAlive == true)
        {
            print(collision);
            if (Mathf.Abs(collision.rigidbody.velocity.y) >= velocityThreshold || 
                Mathf.Abs(collision.relativeVelocity.x) >= velocityThreshold)
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
    }
   

   


}
