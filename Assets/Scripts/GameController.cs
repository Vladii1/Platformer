using UnityEngine;
using System.Collections;
public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject player;
    public GameObject currentCheckPoint;

   
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
   

    public IEnumerator  PlayerRespown()
    {
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerController>().isAlive = false; 
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        yield return new WaitForSeconds(3);
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = currentCheckPoint.transform.position;
        player.GetComponent<PlayerController>().isAlive = true;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
