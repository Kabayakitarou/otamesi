using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControllerWeapon : MonoBehaviour
{
    public Animator StarterAssetsThirdPersonTest;
    public Collider WeaponCollider;
    bool isRun;

    void Start()
    {
        isRun = false;
    }

    // ずっと実行される
    void Update()
    {
       Attack();
       isRun = false;
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
        isRun = true;
        WeaponCollider.enabled = false;
        StarterAssetsThirdPersonTest.SetBool("Attack", false);
    }

}
