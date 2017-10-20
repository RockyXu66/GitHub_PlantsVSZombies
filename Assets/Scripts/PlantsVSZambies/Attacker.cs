using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("Average number of seconds between spawn")]
    public float seenEverySeconds;

    //// Set range for walk speed
    //[Range(-1.0f, 1.5f)] public float currentSpeed;
    private float currentSpeed;

    private GameObject currentTarget;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        // Move the attacker
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        // Check if there is any target to make sure that attacker keeps moving after destroy the defender
        if(!currentTarget){
            anim.SetBool("IsAttacking", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name + " trigger enter");
    }

    public void SetSpeed(float speed){
        currentSpeed = speed;
    }

    // Called from the animator at the time of actual blow
    public void StrikeCurrentTarget(float damage){
        if(currentTarget){
            Health targetHealth = currentTarget.GetComponent<Health>();
            if(targetHealth){
                targetHealth.DealDamage(damage);
            }
        }

    }

    public void Attack(GameObject obj){
        currentTarget = obj;
    }

}
