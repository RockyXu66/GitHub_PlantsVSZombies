using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectilePrefab, gun;

    private GameObject projectileParent;

    private Animator anim;

    private AttackerSpawner myLaneSpawner;

    private void Start()
    {
        
        projectileParent = GameObject.Find("Projectiles");
        // Create a parent if necessary
        if(!projectileParent){
            projectileParent = new GameObject("Projectiles");
        }

        anim = GetComponent<Animator>();

        // Find all lanes spawner and find this lane's spawner
        SetMyLaneSpawner();
    }

    private void Update()
    {
        // Check if there is any attacker ahead in lane and set corresponding animation state
        if(IsAttackerAheadInLane()){
            anim.SetBool("IsAttacked", true);
        }else{
            anim.SetBool("IsAttacked", false);
        }
    }

    private void Fire(){
        GameObject projectile = Instantiate(projectilePrefab) as GameObject;
        projectile.transform.parent = projectileParent.transform;
        projectile.transform.position = gun.transform.position;
    }

    // Find all lanes spawner and find this lane's spawner
    private void SetMyLaneSpawner(){
        AttackerSpawner[] allLanesSpawner = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in allLanesSpawner){
            // Shooter and my lane spawner has same y position
            if(spawner.transform.position.y == transform.position.y){
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find spawner in lane");
    }

    private bool IsAttackerAheadInLane(){

        // Exit if no attackers in lane
        if(myLaneSpawner.transform.childCount <= 0){
            return false;
        }

        // If there are attackers, are they ahead?
        foreach (Transform attacker in myLaneSpawner.transform){
            Vector3 pos = attacker.transform.position;
            if(pos.x > transform.position.x){
                return true;
            }
        }

        //Attacker[] attackers = myLaneSpawner.GetComponentsInChildren<Attacker>();
        //foreach(Attacker attacker in attackers){
        //    Vector3 pos = attacker.transform.position;
        //    if (pos.x > transform.position.x && pos.x < 9.0f){
        //        return true;
        //    }
        //}

        // Attackers in lane, but behind shooter.  
        return false;
    }

}
