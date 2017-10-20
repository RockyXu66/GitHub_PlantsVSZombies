using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    public string[] levelNameArray;

    private AudioSource audioSource;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
        //SceneManager.GetAllScenes();
        audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Level Loaded");
        //Debug.Log(scene.name);
        //Debug.Log(mode);

        // Find the loaded level index in levelNames array
        for (int i = 0; i < levelNameArray.Length; i++){
            if(levelNameArray[i]==scene.name){
                // Load corresponding index music
                AudioClip thisLevelMusic = levelMusicChangeArray[i];

                if(thisLevelMusic){     // If there is some music attached   
                    audioSource.clip = thisLevelMusic;
                    audioSource.loop = true;
                    audioSource.Play();
                    //Debug.Log("play music here");
                }
            }
        }
    }

    // Change volume value by volume slider
    public void SetVolume(float value){
        audioSource.volume = value;
    }
}
