using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    public int count;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && GameController.instance.currentCheckPoint.GetComponent<CheckPoint>().count < count)
        {
            
            GameController.instance.currentCheckPoint = gameObject;
        }
        

    }
}
