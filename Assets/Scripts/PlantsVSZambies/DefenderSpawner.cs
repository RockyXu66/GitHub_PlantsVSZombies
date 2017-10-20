using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;

    private GameObject parent;

    private StarsDisplay starsDisplay;

    private Animator starsTextAnim;

    void Start(){
        myCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        parent = GameObject.Find("Defenders");
        if(!parent){
            parent = new GameObject("Defenders");
        }

        starsDisplay = FindObjectOfType<StarsDisplay>();

        starsTextAnim = starsDisplay.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (GameStatus.isPlay)
        {
            DealWithDefender();
        }
    }

    private void DealWithDefender()
    {
        // Get the selected defender prefab from the selected button object
        GameObject defenderPrefab = SelectDefenderButton.selectedDefender;
        // If there is defender selected
        if (defenderPrefab){
            int starsCost = defenderPrefab.GetComponent<Defender>().starsCost;
            // If there is enough stars, then spend it and spawn new defender
            if (starsDisplay.SpendStars(starsCost) == StarsDisplay.Status.SUCCESS)
            {
                SpawnDefender(defenderPrefab);
            }
            else
            {
                // Otherwise give reminder to user
                starsTextAnim.SetTrigger("IsReminded");
            }
        }

    }

    private void SpawnDefender(GameObject defenderPrefab)
    {
        Vector2 pos = SnapToGrid(CalculateWorldPointOfMouseClick());
        GameObject newDefender = Instantiate(defenderPrefab, pos, Quaternion.identity) as GameObject;
        newDefender.transform.parent = parent.transform;
    }

    Vector2 CalculateWorldPointOfMouseClick(){
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        // Set distance from camera with any value because this is 2d game with orthographic camera
        // which is unimportant
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }


    // Get position in grid accroding to the world position
    Vector2 SnapToGrid(Vector2 rowWorldPos){
        //int x = (int)rowWorldPos.x;
        //int y = (int)rowWorldPos.y;
        //float offsetX = rowWorldPos.x - x;
        //float offsetY = rowWorldPos.y - y;

        //if (offsetX > 0.5f){
        //    x += 1;
        //}
        //if (offsetY > 0.5f){
        //    y += 1;
        //}
        // Use Math function RoundToInt to get nearest whole number
        float x = Mathf.RoundToInt(rowWorldPos.x);
        float y = Mathf.RoundToInt(rowWorldPos.y); 

        return new Vector2(x, y);
    }

}
