using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour {

    public float totalSeconds;

    private Slider slider;
    private bool isEndOfLevel;  // A flag to save the level status
    private LevelManager levelManager;  // Used to jump to next level
    private AudioSource audioSource;
    private GameObject winText; 

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        levelManager = FindObjectOfType<LevelManager>();
        isEndOfLevel = false;
        audioSource = GetComponent<AudioSource>();
        winText = GameObject.Find("Win Text");
        winText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        // Update slider in every frame
        slider.value = Time.timeSinceLevelLoad / totalSeconds;
        // If slider ended and isEndOfLevel not true, then end the level and jump to next level
        if(Time.timeSinceLevelLoad >= totalSeconds && !isEndOfLevel)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        isEndOfLevel = true;
        audioSource.Play();
        winText.SetActive(true);
        // Load next level after audio clip is finished
        Invoke("LoadNextLevel", audioSource.clip.length);
    }

    private void LoadNextLevel(){
        levelManager.LoadNextLevel();
    }
}
