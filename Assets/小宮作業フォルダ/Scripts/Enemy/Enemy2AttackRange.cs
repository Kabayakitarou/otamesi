using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AttackRange : MonoBehaviour
{
    public string AttackDetermination;
    public Enemy2Controller enemycontroller;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            enemycontroller.Attack();
        }
    }
}
