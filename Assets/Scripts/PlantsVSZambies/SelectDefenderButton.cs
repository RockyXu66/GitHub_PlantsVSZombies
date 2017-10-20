using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectDefenderButton : MonoBehaviour {

    public GameObject defenderPrefab;

    // Set a static selected defender gameobject
    public static GameObject selectedDefender; 

    private SelectDefenderButton[] arrayButtons;

    private Text healthText;

	// Use this for initialization
	void Start () {
        // Find all objects by using find ===objects!=== of type funciton
        arrayButtons = FindObjectsOfType<SelectDefenderButton>();

        healthText = GetComponentInChildren<Text>();
        if(!healthText){ Debug.LogWarning(name + " have no health text");   }
        healthText.text = defenderPrefab.GetComponent<Defender>().starsCost.ToString();
	}


    // OnMouseDown function works both on mouse click and finger click
    private void OnMouseDown()
    {
        // Set all other unselected button to black
        foreach (SelectDefenderButton button in arrayButtons){
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }

        // Set selected button to white
        GetComponent<SpriteRenderer>().color = Color.white;

        // Get prefab gameobject when selected by user
        selectedDefender = defenderPrefab;
    }

     
}
