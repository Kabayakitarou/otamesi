using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public Animator Animator;
    public static AttackRange instance {get; private set; }
    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void Attack()
    {
        Animator.SetBool("Attack", true);
    }
}
