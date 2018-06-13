using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageScenes : MonoBehaviour {
    public static ManageScenes instance;
    public int lastPlayedLevel;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void Exit()
    {
        Application.Quit();
    }

    public IEnumerator LoadNextLevlWithWait()
    {
        yield return new WaitForSeconds(1);
        lastPlayedLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void RestartLevel()
    {
        lastPlayedLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        
    }

    public void LoadNextLevel()
    {
        lastPlayedLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void LoadLastPlayedLevel()
    {
        SceneManager.LoadSceneAsync(lastPlayedLevel);
    }
    public void LoadMainMenu()
    {
        lastPlayedLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(0);
    }

}


