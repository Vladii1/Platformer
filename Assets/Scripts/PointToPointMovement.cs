using UnityEngine;
using System.Collections;

public class PointToPointMovement : MonoBehaviour {
    EnemyMoveLeftToRight moveScript;
	// Use this for initialization
	void Start () {
        moveScript = GetComponent<EnemyMoveLeftToRight>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PointToPointTrigger")
        {
            moveScript.ChangeDirection();
        }
    }
}
