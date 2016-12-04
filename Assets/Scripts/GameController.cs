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

    public void PlayerRespown()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.transform.position = currentCheckPoint.transform.position;
    }
}
