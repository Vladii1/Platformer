using UnityEngine;
using System.Collections;

class Impact : MonoBehaviour {
    [SerializeField]
    private float velocityThresholdEnemy;
    [SerializeField]
    private float velocityThresholdShield;
    [SerializeField]
    Collider2D coll;
    private void Update()
    {

    }
    //OnCollisionEnter2D
    void Contact (Collision2D collision, float velocityThreshold)
    {
        if (collision.gameObject.tag == "Player") //collision.gameObject.GetComponent<PlayerController>().isAlive == true)
        {
            print(collision);
            if (Mathf.Abs(collision.rigidbody.velocity.y) >= velocityThreshold || Mathf.Abs(collision.relativeVelocity.x) >= velocityThreshold)
            {
                Destroy(gameObject);
                if (transform.parent != null) Destroy(transform.parent.gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerController>().ModifyHP(-10);
                collision.gameObject.GetComponent<PlayerController>().PushPlayerBack();

            }
        }
    }
    //OnTriggerEnter2D
    void Contact (Collider2D collider, float velocityThreshold)
    {
        if (collider.gameObject.tag == "Player") // && collider.gameObject.GetComponent<PlayerController>().isAlive == true)
        {
            if (Mathf.Abs(collider.GetComponent<Rigidbody2D>().velocity.y) >= velocityThreshold || 
                Mathf.Abs(collider.GetComponent<Rigidbody2D>().velocity.x) >= velocityThreshold)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                //if (transform.parent != null) Destroy(transform.parent.gameObject);
            }
            else
            {
                //collider.GetComponent<PlayerController>().SlowPlayerDown();
                collider.GetComponent<PlayerController>().ModifyHP(-10);
                collider.GetComponent<PlayerController>().PushPlayerBack();
                
            }
        }
    } 

    void OnCollisionEnter2D(Collision2D collision)
    {
        Contact(collision, velocityThresholdEnemy);
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Contact(collider, velocityThresholdShield);
        
    }


}
