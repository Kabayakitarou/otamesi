using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;

    public Transform EnemyPlace1;
    public Transform EnemyPlace2;

    float TimeCount;

    public int Count;
    public int MaxCount;

    // Update is called once per frame
    void Update()
    {
        if(MaxCount <= Count)
        {
            return;
        }

        TimeCount += Time.deltaTime;
        if(TimeCount > 5)
        {
            Instantiate(Enemy1, EnemyPlace1.position, Quaternion.identity);
            Count++;

            Instantiate(Enemy2, EnemyPlace2.position, Quaternion.identity);
            Count++;

            TimeCount = 0;
        }
    }
}
