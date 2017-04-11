using UnityEngine;
using System.Collections;

public class DestroyOnImpact : MonoBehaviour {
    public float velocityThreshold;
    GameObject parent;
    public Collider2D mainCollider;
    public Collider2D otherCollider;
	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && coll.gameObject.GetComponent<PlayerController>().isAlive == true)
        {
            //print(coll.rigidbody.velocity.y);
            //if (Mathf.Abs(coll.rigidbody.velocity.y) >= velocityThreshold || Mathf.Abs(coll.relativeVelocity.x) >= velocityThreshold)
            //{
            //    Destroy(gameObject);
            //    if (transform.parent != null) Destroy(transform.parent.gameObject);
            //}
            //else 
            //{
                StartCoroutine(coll.gameObject.GetComponent<EmitParticle>().InstantiateParticle());
                StartCoroutine(GameController.instance.PlayerRespown());
            }
        }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>().isAlive == true)
        {
            Destroy(gameObject);
            if (transform.parent != null) Destroy(transform.parent.gameObject);
        }
    }
}
