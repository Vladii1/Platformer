using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(WaitForDestroy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        
    }
}
