using UnityEngine;
using System.Collections;

public class EmitParticle : MonoBehaviour {
    public ParticleSystem particle;


    ParticleSystem.MainModule particleMain;
    // Use this for initialization
    void Awake () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public IEnumerator InstantiateParticle()
    {
        print("Particle Emiter used");
        //Instantiate(particle, transform.position, Quaternion.identity,gameObject.transform);
        Instantiate(particle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        //Destroy(gameObject.transform.Find("Particle System(Clone)").gameObject);
    }
    //public void InstantiateParticle()
    //{
    //    Instantiate(particle, transform.position, Quaternion.identity);
    //}
}
