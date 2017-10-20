using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    //void OnTriggerStay(Collider2D collision)
    //{
    //    Attacker attacker = collision.gameObject.GetComponent<Attacker>();

    //    if (attacker)
    //    {
    //        animator.SetTrigger("AttackedTrigger");
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            animator.SetTrigger("AttackedTrigger");
        }
    }
}
