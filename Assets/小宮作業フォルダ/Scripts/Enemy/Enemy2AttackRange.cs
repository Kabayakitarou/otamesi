using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AttackRange : MonoBehaviour
{
    public string AttackDetermination;
    public Enemy2Controller enemy2controller;
    public Animator Enemy2controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            Enemy2controller.SetBool("Run", false);
            enemy2controller.AttackGo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == AttackDetermination)
        {
            enemy2controller.Update();
            Enemy2controller.SetBool("Attack", false);
        }
    }
}
