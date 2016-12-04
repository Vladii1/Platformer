using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {
    public static InterfaceManager instance;
    public Text powerText;
    public Text hpText;
    // Use this for initialization


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }
    

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
