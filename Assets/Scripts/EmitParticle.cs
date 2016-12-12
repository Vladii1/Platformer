using UnityEngine;
using System.Collections;

public class EmitParticle : MonoBehaviour {
    public ParticleSystem particle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void InstantiateParticle()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
