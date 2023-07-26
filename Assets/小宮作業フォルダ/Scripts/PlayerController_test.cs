using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController_test : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed;
    public float RotationSpeed;

    Vector3 speed = Vector3. zero;
    Vector3 rot = Vector3. zero;

    public Animator PlayerAnimator;
    bool isRun;

    public Collider WeaponCollider;
    bool canMove = true;

    void Start () 
    {
        Cursor.visible = false;
        // カーソルをウィンドウから出さない
        Screen.lockCursor = true;
    }

    // ずっと実行される
    void Update()
    {
       Move();
       Rotation();
       Attack();
       Camera. transform. position = transform. position;
    }

    void Move()//WASDの操作
    {
        if(!canMove)
        {
            return;
        }
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


    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayerAnimator.SetBool("Attack", true);
            canMove = false;
        }
    }

    void WeaponON()
    {
        WeaponCollider.enabled = true;
    }

    void WeaponOFF()
    {
        WeaponCollider.enabled = false;
        PlayerAnimator.SetBool("Attack", false);
    }

    void CanMove()
    {
        canMove = true;
    }
}
