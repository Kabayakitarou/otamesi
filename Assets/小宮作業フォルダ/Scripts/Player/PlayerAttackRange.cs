using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
    // サーチした敵を入れる
    [SerializeField]
    private List<GameObject> enemyList;
    // 現在標的にしている敵
    [SerializeField]
    private GameObject nowTarget;
    private GameObject nearTarget;

    void Update() 
    {
        TargetOthers();
    }
 
    void TargetOthers() 
    {
        // ターゲットのゲームオブジェクト
        GameObject nearTarget = null;
 
        if (nearTarget != null) 
        {
            transform.LookAt(nowTarget.transform);
        }
    }

    void OnTriggerEnter(Collider col) 
    {
        if (col.tag == "Enemy") 
        {
            nowTarget = nearTarget;
        }
    }

    void OnTriggerExit(Collider col) 
    {
        // ターゲットになっていたらターゲットを解除
        if (col.gameObject == nowTarget) 
        {
            nowTarget = null;
        }
    }

    // 現在のターゲットを返す
    public GameObject GetNowTarget() 
    {
        return nowTarget;
    }

    // ターゲットを設定
    public void SetNowTarget() 
    {
        
        // 一番近い敵を標的に設定する
        foreach (var enemy in enemyList) 
        {
            // 敵が死んだ時に呼び出して敵をリストから外す
            if (nowTarget == null) 
            {
                nowTarget = null;
            }

            // ターゲットがいなくて敵との間に壁がなければターゲットにする
            if (nowTarget == null) 
            {
                nowTarget = enemy;
            } 

            // ターゲットがいる場合で今の敵の方が近ければ今の敵をターゲットにする
            else if (Vector3.Distance(transform.parent.position, enemy.transform.position) < Vector3.Distance(transform.parent.position, nowTarget.transform.position) && !Physics.Linecast(transform.parent.position + Vector3.up, enemy.transform.position + Vector3.up, LayerMask.GetMask("Field")))
            {
                nowTarget = enemy;
            }
        }
    }
}

