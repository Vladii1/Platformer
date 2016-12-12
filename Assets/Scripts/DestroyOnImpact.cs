using UnityEngine;
using System.Collections;

public class DestroyOnImpact : MonoBehaviour {
    public float velocityThreshold;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            print(coll.rigidbody.velocity.y);
            if (Mathf.Abs(coll.rigidbody.velocity.y) >= velocityThreshold || Mathf.Abs(coll.relativeVelocity.x) >= velocityThreshold)
            {
                Destroy(gameObject);

            }

            else
            {
                coll.gameObject.GetComponent<EmitParticle>().InstantiateParticle();
                GameController.instance.PlayerRespown();
            }
        }
    }
}
