using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed;
    public float RotationSpeed;

    Vector3 speed = Vector3. zero;
    Vector3 rot = Vector3. zero;
    
    public Animator PlayerAnimator;
    bool isRun;

    // 最初だけ実行される
    void Start()
    {
        
    }

    // ずっと実行される
    void Update()
    {
       Move();
       Rotation();
       Camera. transform. position = transform. position;
    }

    void Move()//WASDの操作
    {
        speed = Vector3. zero;
        rot = Vector3. zero;
        isRun = false;

        if(Input.GetKey(KeyCode. W))
        {
            rot. y = 0;
            MoveSet();
        }
        if(Input.GetKey(KeyCode. S))
        {
            rot. y = 180;
            MoveSet();
        }
        if(Input.GetKey(KeyCode. A))
        {
            rot. y = -90;
            MoveSet();
        }
        if(Input.GetKey(KeyCode. D))
        {
            rot. y = 90;
            MoveSet();
        }

        
        transform.Translate(speed);
        PlayerAnimator.SetBool("Run", isRun);
    }

    void MoveSet()//方向転換
    {
        speed. z = PlayerSpeed;
        transform. eulerAngles = Camera. transform. eulerAngles + rot;
        isRun = true;
    }

    void Rotation()//回転の操作
    {
        var speed = Vector3. zero;
        if(Input.GetKey(KeyCode. LeftArrow))
        {
            speed.y = -RotationSpeed;
        }
        if(Input.GetKey(KeyCode. RightArrow))
        {
            speed.y = RotationSpeed;
        }

        Camera. transform. eulerAngles += speed;
    }
}
