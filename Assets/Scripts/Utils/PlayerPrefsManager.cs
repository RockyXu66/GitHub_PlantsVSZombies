using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    // const are also static in C# !!!
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume){
        if (volume >= 0f && volume <= 1f){
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);    
        }else{
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume(){
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level){
        if(level <= SceneManager.sceneCountInBuildSettings-1){
            PlayerPrefs.SetInt(DIFFICULTY_KEY+level.ToString(), 1); // Use 1 for true (unlocked)
        }else{
            Debug.LogError("Try to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level){
        if(level <= SceneManager.sceneCountInBuildSettings - 1){
            if (PlayerPrefs.GetInt(DIFFICULTY_KEY + level.ToString()) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }else{
            Debug.LogError("Try to unlock level not in build order");
            return false;
        }
    }

    // Set difficulty level to 1 -- 3
    public static void SetDifficulty(float diff){
        if (diff >= 1f && diff <= 3f){
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }else{
            Debug.LogError("Difficulty out of range");
        }
    }

    public static float GetDifficulty(){
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
