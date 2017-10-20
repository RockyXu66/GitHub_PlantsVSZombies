using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarsDisplay : MonoBehaviour {

    private Text starsDisplayText;

    public int stars = 100;

    public enum Status { SUCCESS, FAILURE };

	// Use this for initialization
	void Start () {
        starsDisplayText = GetComponent<Text>();
        UpdateDisplay();
	}

    // Don't need to update stars text every frame in Update() funcition
    // Just change the text every time when stars changed
    void UpdateDisplay(){
        starsDisplayText.text = stars.ToString();
    }

    public void AddStars(int amount){
        stars += amount;
        UpdateDisplay();
    }

    public Status SpendStars(int amount){
        if(stars >= amount){
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }else{
            return Status.FAILURE;
        }

    }

}
