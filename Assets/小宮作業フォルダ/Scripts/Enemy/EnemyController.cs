using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator Enemy1controller;
    public float Timer;
    public float ChangeTime;
    public float WalkSpeed;
    public float RunSpeed;
    public GameObject target;
    public GameObject myself;
    GameObject Target;

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;//敵の移動速度
        speed.z = WalkSpeed;
        var rot = transform.eulerAngles;

        Enemy1controller.SetBool("Run", false);

        Vector3 targetPos = target.transform.position;
        Vector3 myselfPos = myself.transform.position;

        if(Target)
        {
            transform.LookAt(Target.transform);
            rot = transform.eulerAngles;
            speed.z = RunSpeed;
            Enemy1controller.SetBool("Run", true);
            if(Vector3.Distance(target.transform.position, myself.transform.position) <= 5f)
            {
                Enemy1controller.SetBool("Run", false);
                print("Distance to other: " + Vector3.Distance(target.transform.position, myself.transform.position));
                speed.z = 0;
                Enemy1controller.SetBool("Attack", true);
            }

        }
        else
        {
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

        rot.x = 0;
        rot.z = 0;
        transform.eulerAngles = rot;

        this.transform.Translate(speed);
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
