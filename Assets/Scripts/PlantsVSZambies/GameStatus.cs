using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour{

    public Sprite playSprite, pauseSprite;

    public static bool isPlay;

    private GameObject statusBtn;

    private GameObject pausePanel;

    private void Start()
    {
        statusBtn = GameObject.Find("Status Button");
        isPlay = true;
        pausePanel = GameObject.Find("PausePanel");
        pausePanel.SetActive(false);
    }

    public void SetStatus(){
        if(isPlay){
            Time.timeScale = 0;
            //Debug.Log("Pause");
            isPlay = false;
            pausePanel.SetActive(true);
            //statusBtn.GetComponent<Image>().sprite = null;
            statusBtn.GetComponent<Image>().enabled = false;
        }else{
            //Debug.Log("Play");
            Time.timeScale = 1;
            isPlay = true; 
            pausePanel.SetActive(false);
            statusBtn.GetComponent<Image>().enabled = true;
            //statusBtn.GetComponent<Image>().sprite = pauseSprite;
        }
    }

}
