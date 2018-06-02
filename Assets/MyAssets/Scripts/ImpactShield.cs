using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactShield : MonoBehaviour {
    [SerializeField]
    private float velocityThresholdShield;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Contact(collider, velocityThresholdShield);

    }
    //OnTriggerEnter2D
    void Contact(Collider2D collider, float velocityThreshold)
    {
        if (collider.gameObject.tag == "Player") // && collider.gameObject.GetComponent<PlayerController>().isAlive == true)
        {
            if (Mathf.Abs(collider.GetComponent<Rigidbody2D>().velocity.y) >= velocityThreshold ||
                Mathf.Abs(collider.GetComponent<Rigidbody2D>().velocity.x) >= velocityThreshold)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                collider.GetComponent<PlayerController>().SlowPlayerDown();
            }
            else
            {
                collider.GetComponent<PlayerController>().ModifyHP(-1);
                collider.GetComponent<PlayerController>().PushPlayerBack(transform.position.x);

            }
        }
    }
}
