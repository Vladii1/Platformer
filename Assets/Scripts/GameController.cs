using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance;
    
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
