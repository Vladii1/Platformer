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
                StartCoroutine(collision.gameObject.GetComponent<EmitParticle>().InstantiateParticle());
                StartCoroutine(GameController.instance.PlayerRespown());
            }
        }
    }
    void Contact (Collider2D collider, float velocityThreshold)
    {
        if (collider.gameObject.tag == "Player") // && collider.gameObject.GetComponent<PlayerController>().isAlive == true)
        {
            //print(velocityThreshold);
            //print(Mathf.Abs(collider.GetComponent<Rigidbody2D>().velocity.y));
            //print(Mathf.Abs(collider.GetComponent<Rigidbody2D>().velocity.x));
            if (Mathf.Abs(collider.GetComponent<Rigidbody2D>().velocity.y) >= velocityThreshold || 
                Mathf.Abs(collider.GetComponent<Rigidbody2D>().velocity.x) >= velocityThreshold)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                if (transform.parent != null) Destroy(transform.parent.gameObject);
            }
            else
            {
                StartCoroutine(GameController.instance.PlayerRespown());
                StartCoroutine(collider.GetComponent<EmitParticle>().InstantiateParticle());
                
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
