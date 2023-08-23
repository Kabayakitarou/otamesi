using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public Animator Enemy2controller;
    public float Timer;
    public float ChangeTime;
    public float WalkSpeed;
    public float RunSpeed;
    GameObject Target;

    // Update is called once per frame
    void Update()
    {
        Enemy2controller = GetComponent<Animator>();

        var speed = Vector3.zero;//敵の移動速度
        var rot = transform.eulerAngles;

        Enemy2controller.SetBool("Run", false);

        if(Target)
        {
            transform.LookAt(Target.transform);
            rot = transform.eulerAngles;
            speed.z = RunSpeed;
            Enemy2controller.SetBool("Run", true);
        }
        else
        {
            speed.z = WalkSpeed;
            Timer += Time.deltaTime;
            if(ChangeTime <= Timer)
            {
                float WalkIdle = Random.Range(0, 1);
                if(WalkIdle == 0)
                {
                    Enemy2controller.SetBool("Walk", true);
                    float rand = Random.Range(0, 360);
                    rot.y = rand;
                    Timer = 0;
                }
                else if(WalkIdle == 1)
                {
                    speed.z = 0;
                    Enemy2controller.SetBool("Walk", false);
                }
            }
        }

        if (Enemy2controller.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            speed.z = 0;
        }

        rot.x = 0;
        rot.z = 0;
        transform.eulerAngles = rot;

        this.transform.Translate(speed);

    }

    public void Attack()
    {
        Enemy2controller.SetTrigger("Attack");
        Invoke("Attack", 3.0f);
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
