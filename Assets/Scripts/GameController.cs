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
    private void Start()
    {
       // StartCoroutine(PlayerRespown());
    }
    public IEnumerator  PlayerRespown()
    {
        player.GetComponent<PlayerController>().isAlive = false;
        player.GetComponent<Collider2D>().enabled = false;
        player.transform.Find("Minion Animation").gameObject.SetActive(false);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        yield return new WaitForSeconds(2);
        player.GetComponent<Collider2D>().enabled = true;
        player.transform.Find("Minion Animation").gameObject.SetActive(true);
        player.transform.position = currentCheckPoint.transform.position;
        player.GetComponent<PlayerController>().isAlive = true;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
