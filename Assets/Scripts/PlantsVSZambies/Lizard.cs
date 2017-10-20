using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Lizard : MonoBehaviour {
    
    Animator anim;
    Attacker attacker;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        // Leave the method if not colliding with defender, such as projectile
        if(!obj.GetComponent<Defender>()){
            return;
        }

        // If colliding with any other things, set animation trigger to true and attack them
        anim.SetBool("IsAttacking", true);
        attacker.Attack(obj);

    }
}
