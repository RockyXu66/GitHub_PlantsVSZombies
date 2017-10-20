using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;

    private Image fadeInPanel;
    private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
        fadeInPanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        // Get load time by using Time.timeSinceLevelLoad
        if (Time.timeSinceLevelLoad < fadeInTime){
            // Fade in
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            fadeInPanel.color = currentColor;
        }else{
            // After finishing fade in process, set active false. 
            // Otherwise we cannot click the button below the panel
            gameObject.SetActive(false);
        }
	}
}
