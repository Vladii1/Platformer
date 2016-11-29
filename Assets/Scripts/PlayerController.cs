using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpHeight);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			rigidbody2D.velocity = new Vector2 (-speed, rigidbody2D.velocity.y);
		}

		/*
		if (Input.GetAxis ("Horizontal")!=0|| Input.GetAxis("Vertical")!=0) 
		{
			rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, 0);
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, Input.GetAxisRaw ("Vertical") * jumpHeight);
		}
	*/
	}
}
