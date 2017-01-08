using UnityEngine;
using System.Collections;

public class PointToPointMovement : MonoBehaviour {
    public EnemyMove moveScript;
	// Use this for initialization
	void Start () {
        moveScript = moveScript.GetComponent<EnemyMove>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == moveScript.gameObject.name)
        {
            moveScript.ChangeDirection();
        }
    }
}
