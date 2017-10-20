using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        // If collided with attacker, then lose the game.
        if(obj.GetComponent<Attacker>()){
            LoseGame();
        }
    }

    private void LoseGame(){
        levelManager.LoadLevel("PVZ_03b Lose");
    }
}
