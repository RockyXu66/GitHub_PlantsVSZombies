using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;

    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        // Only when there is MusicManager object, can we get the musicManager.
        // Otherwise we get NULL
        // MusicManager is inside Persistent Music object, so we have to open load_scene first
        musicManager = FindObjectOfType<MusicManager>();

        // Set value to slider when start loading this scene
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        if(musicManager){
            // Change value according to slider value
            musicManager.SetVolume(volumeSlider.value);
        }
	}

    public void SaveAndExit(){
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        SceneManager.LoadScene("PVZ_01a Start");
    }

    public void Default(){
        volumeSlider.value = 0.2f;
        difficultySlider.value = 2f;
    }
}
