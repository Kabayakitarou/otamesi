using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControllerWeapon : MonoBehaviour
{
    public Animator StarterAssetsThirdPersonTest;
    public Collider WeaponCollider;

    void Start()
    {

    }

    // ずっと実行される
    void Update()
    {
       Attack();
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StarterAssetsThirdPersonTest.SetBool("Attack", true);
        }
    }
    void WeaponON()
    {
        WeaponCollider.enabled = true;
    }
    void WeaponOFF()
    {
        WeaponCollider.enabled = false;
        StarterAssetsThirdPersonTest.SetBool("Attack", false);
    }

}
