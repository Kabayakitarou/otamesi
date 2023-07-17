using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float time;

    public float EnemySpeed;
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

        this.transform.Translate(speed);
    }
}
