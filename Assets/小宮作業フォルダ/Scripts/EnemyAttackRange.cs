using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    public Animator Animator;
    public string AttackDetermination;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            Attack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            Attack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            AttackStop();
        }
    }

    // Update is called once per frame
    public void Attack()
    {
        Animator.SetTrigger("Attack");
    }

    public void AttackStop()
    {
        Animator.SetTrigger("Attack");
    }
}
