using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    private GameObject starsDisplay, movingStar;

    private bool isMoving;  // Flag to decide if it's moving 

    private Vector3 deltaPos, deltaScal;    // delta position and scale between moving star and display star

    private void Start()
    {
        starsDisplay = GameObject.Find("Star Image");//FindObjectOfType<StarsDisplay>().transform.GetChild(1).transform.gameObject;
        movingStar = transform.GetChild(0).GetChild(1).transform.gameObject;
        isMoving = false;
        ResetMovingStarToInitial();
        movingStar.SetActive(false);
    }

    private void Update()
    {

        // Animation here
        if(isMoving){
            movingStar.transform.localScale += deltaScal * Time.deltaTime;
            movingStar.transform.position += deltaPos * Time.deltaTime;
        }
    }

    // Even triggered by animation of trophy
    public void MoveToDisplay()
    {
        
        if(isMoving){
            isMoving = false;
            ResetMovingStarToInitial();
            movingStar.SetActive(false);
        }else{
            isMoving = true;
            deltaPos = starsDisplay.transform.position - movingStar.transform.position;
            deltaScal = new Vector3(0.09f, 0.09f, 0.09f) - movingStar.transform.localScale;
            movingStar.SetActive(true);
        }

    }

    private void ResetMovingStarToInitial()
    {
        movingStar.transform.localPosition = new Vector3(0f, 1.292f, 0f);
        movingStar.transform.localScale = new Vector3(0.1375452f, 0.1375452f, 0.1375452f);
    }
}
