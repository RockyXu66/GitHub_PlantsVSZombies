using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

	public void LoadLevel (string name){
		SceneManager.LoadScene(name);
		//Brick.brickCount = 0;
	}	

	public void QuitRequest (string name){
//		Debug.Log("I want to quit and go back to start menu");
		SceneManager.LoadScene(name);
	}

    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	//public void AllBricksDestroyed(){
	//	if(Brick.brickCount<=0){
	//		SceneManager.LoadScene("BreakOut_Scene(02)");
	//	}
	//}
}
