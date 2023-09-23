using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public Animator Enemy2animator;
    public float Timer;
    public float ChangeTime;
    public float WalkSpeed;
    public float RunSpeed;
    internal GameObject Target;

    void Start(){
        Enemy2animator.SetBool("Run", false);
    }

    public void Update()
    {
        Enemy2animator = GetComponent<Animator>();

        var speed = Vector3.zero;//敵の移動速度
        var rot = transform.eulerAngles;

        if(Target)//Playerを見つけた
        {
            Enemy2animator.SetBool("Run", true);
            transform.LookAt(Target.transform);
            rot = transform.eulerAngles;
            RunSpeed = 0.005f;
            speed.z = RunSpeed;
        }
        else
        {
            Enemy2animator.SetBool("Run", false);
            WalkSpeed = 0.002f;
            speed.z = WalkSpeed;
            Timer += Time.deltaTime;
            if(ChangeTime <= Timer)
            {
                float WalkIdle = Random.Range(0, 1);
                if(WalkIdle == 0)
                {
                    Enemy2animator.SetBool("Walk", true);
                    float rand = Random.Range(0, 360);
                    rot.y = rand;
                    Timer = 0;
                }
                else if(WalkIdle == 1)
                {
                    speed.z = 0;
                    Enemy2animator.SetBool("Walk", false);
                }
            }
        }

        if (Enemy2animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            speed.z = 0;
        }

        rot.x = 0;
        rot.z = 0;
        transform.eulerAngles = rot;

        this.transform.Translate(speed);
    }

    void EnemyAttackOn(){
        PlayerStatusManager.Damagenum = 10;
        PlayerStatusManager.instance.EnemyAttack();
    }


    public void AttackGo()
    {
        Enemy2animator.SetBool("Run", false);
        Invoke("Attack", 1.0f);
    }
    public void Attack(){
        Enemy2animator.SetBool("Attack", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Target = other.gameObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Target = null;
        }
    }
}
