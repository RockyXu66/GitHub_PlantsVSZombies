using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    //void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();

        // If the projectile hit attacker and attacker has Health component, then deal with damage
        if(attacker && health){
            health.DealDamage(damage);

            // Destroy projectile after attacking attackers
            Destroy(gameObject);
        }
    }
}
