using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {
        //foreach(GameObject attacker in attackerPrefabArray){
        //    if(isTimeToSpawn(attacker)){
        //        Spawn(attacker);
        //    }
        //}
	}

    bool isTimeToSpawn(GameObject obj){
        Attacker attackerComponent = obj.GetComponent<Attacker>();
        if(attackerComponent){
            float meanSpawnDelay = attackerComponent.seenEverySeconds;
            float spawnsPerSecond = 1 / meanSpawnDelay;

            if(Time.deltaTime > meanSpawnDelay){
                Debug.LogWarning("Spawn rate capped by frame rate");
            }

            // Divided by 5 because there are 5 lanes
            float threshold = spawnsPerSecond * Time.deltaTime / 5; 

            return (Random.value < threshold);
        }

        return false;
    }

    public void Spawn(GameObject obj){
        
        GameObject newAttacker = Instantiate(obj, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
        newAttacker.transform.position = transform.position;
    }
}
