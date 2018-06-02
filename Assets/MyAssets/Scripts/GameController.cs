using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    public static GameController instance;
    GameObject player;
    public GameObject currentCheckPoint;
    public bool playerAlive = true;
    public GameObject playerShadow;
    // public GameObject cinemachine;
    //CinemachineVirtualCameraBase virtualCamera;
    AudioManager audioManager;

    public List<ImpactEnemy> enemyList;
    void Awake()
    {
        enemyList = new  List<ImpactEnemy>();
        //virtualCamera = cinemachine.GetComponent<CinemachineVirtualCamera>();
        //enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);    
        player = GameObject.FindGameObjectWithTag("Player");
        playerShadow = GameObject.Find("Player Shadow");
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            TurnPower(false);
        }
        else TurnPower(true);
    }

    public IEnumerator RestartLevel()
    {
        player.GetComponent<Collider2D>().enabled = false;
        player.transform.Find("Player New Animation").gameObject.SetActive(false);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponentInChildren<JetpackController>().enabled = false;
        player.GetComponentInChildren<JetpackController>().TurnOffEmission();
        playerShadow.SetActive(false);
        audioManager.Play("Player Death");
        yield return new WaitForSeconds(2.5f);
        ManageScenes.instance.RestartLevel();
    }
    public IEnumerator  PlayerRespown()
    {
        playerAlive = false;
       // player.GetComponent<PlayerController>().isAlive = false;
        player.GetComponent<Collider2D>().enabled = false;
        player.transform.Find("Player New Animation").gameObject.SetActive(false);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponentInChildren<JetpackController>().enabled = false;
        player.GetComponentInChildren<JetpackController>().TurnOffEmission();
        playerShadow.SetActive(false);

        yield return new WaitForSeconds(2);

        player.GetComponent<Collider2D>().enabled = true;
        player.transform.Find("Player New Animation").gameObject.SetActive(true);
        player.transform.position = currentCheckPoint.transform.position;
        //player.GetComponent<PlayerController>().isAlive = true;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponentInChildren<JetpackController>().enabled = true;
        playerAlive = true;
        playerShadow.SetActive(true);
        InterfaceManager.instance.ResetHP();
    }

    public void RemoveEnemy(ImpactEnemy enemy)
    {
        enemyList.Remove(enemy);
        if (enemyList.Count == 0)
        {
            print("All enemies got killed, move to next level");
            StartCoroutine(ManageScenes.instance.LoadNextLevlWithWait());
        }
    }

    public void AddEnemy(ImpactEnemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void TurnPower(bool isUsingPower)
    {
        player.GetComponent<PlayerController>().isUsingPower = isUsingPower;
        player.GetComponentInChildren<JetpackController>().isUsingPower = isUsingPower;
        InterfaceManager.instance.SwitchPower(isUsingPower);
    }
   
}
