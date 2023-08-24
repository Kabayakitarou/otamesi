using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AttackRange : MonoBehaviour
{
    public string AttackDetermination;
    public Enemy1Controller enemycontroller;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            enemycontroller.Attack();
        }
    }
}
