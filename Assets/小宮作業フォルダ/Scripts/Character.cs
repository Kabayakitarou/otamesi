using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

using static UnityEditor.PlayerSettings;

public class Character : MonoBehaviour
{
    Animator anim;

    float moveZ;
    float moveX;

    float normalSpeed = 6f; //通常の移動速度

    Vector3 moveDirection = Vector3.zero;　//移動方向
    Vector3 startpos;   //開始位置
    Vector3 muki;   //回転
    Vector3 mukikioku; //回転記憶

    float mx;   //マウス移動量x
    float my;   //マウス移動量y

    float xkaitensokudo = 10f;   //x回転速度
    float ykaitensokudo = 10f;   //y回転速度


    float upseigen = 290f;   //上限界角度
    float downseigen = 70f;   //下限界角度



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //animatorのコンポーネントを取得

        // マウスカーソルを非表示にし、位置を固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // 移動設定

        muki = transform.eulerAngles;
        mukikioku = transform.eulerAngles;
        muki.x = 0f;
        muki.z = 0f;

        transform.eulerAngles = muki;

        //前後移動
        moveZ = (Input.GetAxis("Vertical"));
        //左右移動
        moveX = (Input.GetAxis("Horizontal"));

        moveDirection = new Vector3(moveX, 0, moveZ).normalized * normalSpeed * Time.deltaTime;

        this.transform.Translate(moveDirection.x, moveDirection.y, moveDirection.z);

        // 移動のアニメーション
        anim.SetFloat("MoveSpeed", moveDirection.magnitude);

        transform.eulerAngles = mukikioku;

        // マウス向き

        mx = Input.GetAxis("Mouse X");
        my = Input.GetAxis("Mouse Y");

        mx += mx * xkaitensokudo * Time.deltaTime;
        my += my * ykaitensokudo * Time.deltaTime;


        transform.Rotate(-my, mx, 0);

        muki = transform.eulerAngles;

        if (muki.x > downseigen)
        {
            if (muki.x > 180f)
            {

                if (upseigen > muki.x)
                {

                    muki.x = upseigen;
                }
            }
            else
            {
                muki.x = downseigen;
            }

        }

        muki.z = 0f;

        transform.eulerAngles = muki;

    }
}