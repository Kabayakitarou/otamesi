using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float time;

    public float EnemySpeed;

    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, time);//敵の破壊
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;//敵の移動速度
        speed.z = EnemySpeed;

        if(Target)
        {
            transform.LookAt(Target.transform);
        }

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
