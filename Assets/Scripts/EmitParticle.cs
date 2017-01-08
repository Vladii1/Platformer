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
    public IEnumerator InstantiateParticle()
    {
        Instantiate(particle, transform.position, Quaternion.identity,gameObject.transform);
        yield return new WaitForSeconds(3);
        Destroy(gameObject.transform.Find("Particle System(Clone)").gameObject);
    }
    //public void InstantiateParticle()
    //{
    //    Instantiate(particle, transform.position, Quaternion.identity);
    //}
}
