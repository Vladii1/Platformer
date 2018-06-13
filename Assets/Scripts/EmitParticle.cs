using UnityEngine;
using System.Collections;

public class EmitParticle : MonoBehaviour
{
    public ParticleSystem particle;


    ParticleSystem.MainModule particleMain;

    public IEnumerator InstantiateParticle()
    {
        print("Particle Emiter used");
        //Instantiate(particle, transform.position, Quaternion.identity,gameObject.transform);
        Instantiate(particle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        //Destroy(gameObject.transform.Find("Particle System(Clone)").gameObject);
    }
}
