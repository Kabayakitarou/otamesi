using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    public Animator Enemy1controller;
    public float Timer;
    public float ChangeTime;
    public float WalkSpeed;
    public float RunSpeed;
    public int AttackDamage = 5;
    internal GameObject Target;

    public int attacked;

    void Start(){
        Enemy1controller.SetBool("Run", false);
    }

    public void Update()
    {
        Enemy1controller = GetComponent<Animator>();

        var speed = Vector3.zero;//敵の移動速度
        var rot = transform.eulerAngles;

        if(Target)//Playerを見つけた
        {
            Enemy1controller.SetBool("Run", true);
            transform.LookAt(Target.transform);
            rot = transform.eulerAngles;
            RunSpeed = 0.008f;
            speed.z = RunSpeed;
        }
        else
        {
            Enemy1controller.SetBool("Run", false);
            WalkSpeed = 0.005f;
            speed.z = WalkSpeed;
            Timer += Time.deltaTime;
            if(ChangeTime <= Timer)
            {
                float WalkIdle = Random.Range(0, 1);
                if(WalkIdle == 0)
                {
                    Enemy1controller.SetBool("Walk", true);
                    float rand = Random.Range(0, 360);
                    rot.y = rand;
                    Timer = 0;
                }
                else if(WalkIdle == 1)
                {
                    speed.z = 0;
                    Enemy1controller.SetBool("Walk", false);
                }
            }
        }

        if (Enemy1controller.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            speed.z = 0;
        }

        rot.x = 0;
        rot.z = 0;
        transform.eulerAngles = rot;

        this.transform.Translate(speed);
    }

    public void AttackGo()
    {
        Enemy1controller.SetBool("Run", false);
        Invoke("Attack", 1.0f);
    }
    public void Attack(){
        Enemy1controller.SetBool("Attack", true);
        Debug.Log("Attack");
        attacked = 1;
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
