using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int starsCost = 100;

    private StarsDisplay starsDisplay;


    private void Start()
    {
        starsDisplay = FindObjectOfType<StarsDisplay>();
    }

    public void AddStars(int amount){
        starsDisplay.AddStars(amount);
    }

}
