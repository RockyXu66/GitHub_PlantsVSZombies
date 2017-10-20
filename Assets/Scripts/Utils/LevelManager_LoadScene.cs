using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager_LoadScene : MonoBehaviour {

    public float autoLoadNextLevelAfter; // 3 seconds
    public string nextLevelName;

	// Use this for initialization
	void Start () {
        Invoke("LoadNextScene", autoLoadNextLevelAfter);
	}
	
    void LoadNextScene(){
        SceneManager.LoadScene(nextLevelName);
    }

}
