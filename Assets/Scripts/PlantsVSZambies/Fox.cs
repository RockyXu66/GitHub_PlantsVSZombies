using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The fox make no sense without attacker
[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

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

        // Leave the method if not colliding with defender
        if(!obj.GetComponent<Defender>()){
            return;
        }


        if(obj.GetComponent<GraveStone>()){
            // If colliding with stone, set jump trigger to true
            anim.SetTrigger("JumpTrigger");
        }else{
            // If colliding with other things, set animation trigger to true and attack them
            anim.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }
    }
}
