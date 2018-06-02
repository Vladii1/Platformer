using UnityEngine;
using System.Collections;

public class ImpactEnemy : MonoBehaviour {
    [SerializeField]
    private float velocityThresholdEnemy;

    CameraShake camShake;
    float shakeAmount = 1f;
    float shakeLength = 110f;

    EmitParticle particleEmiter;

    private void Awake()
    {
        particleEmiter = GetComponent<EmitParticle>();

    }

    private void Start()
    {
        GameController.instance.AddEnemy(this);
        camShake = GameController.instance.gameObject.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D collisionRb2D = collision.GetComponent<Rigidbody2D>();
            PlayerController collisionPlayerController = collision.GetComponent<PlayerController>();

            print(Mathf.Abs(collisionRb2D.velocity.x) + ", " + Mathf.Abs(collisionRb2D.velocity.y));
            if (Mathf.Abs(collisionRb2D.velocity.x) >= velocityThresholdEnemy ||
                Mathf.Abs(collisionRb2D.velocity.y) >= velocityThresholdEnemy)
            {
               // camShake.OverwriteCameraShake(shakeAmount, shakeLength);
                collisionPlayerController.SlowPlayerDown();
                StartCoroutine(particleEmiter.InstantiateParticle());
                FindObjectOfType<AudioManager>().Play("Destroy");
                if (this.transform.parent != null && this.transform.parent.name != "Enemies") Destroy(this.transform.parent.gameObject);
                GameController.instance.RemoveEnemy(this);
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);

            }
            else
            {
                collisionPlayerController.PushPlayerBack(transform.position.x);
                collisionPlayerController.ModifyHP(-1);
            }
        }
    }

}
