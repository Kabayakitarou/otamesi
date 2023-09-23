using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AttackRange : MonoBehaviour
{
    public string AttackDetermination;
    public Enemy1Controller enemy1controller;
    public Animator Enemy1controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            Enemy1controller.SetBool("Run", false);
            enemy1controller.AttackGo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            enemy1controller.Update();
            Enemy1controller.SetBool("Attack", false);
        }
    }
}
