using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
    public int HP;
    public int Power; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (HP > 0)
            {
                other.GetComponent<PlayerController>().ModifyHP(HP);
                Destroy(gameObject);
            }
            else if (Power > 0)
            {
                other.GetComponent<PlayerController>().ModifyPower(Power);
                Destroy(gameObject);
            }
        }
    }
}
