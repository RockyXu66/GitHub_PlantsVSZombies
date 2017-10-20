using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {

    private GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnMouseDown()
    {
        gameStatus.SetStatus();
    }
}
