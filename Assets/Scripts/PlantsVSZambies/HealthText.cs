using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    public GameObject defender;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = defender.GetComponent<Defender>().starsCost.ToString();
	}
}
