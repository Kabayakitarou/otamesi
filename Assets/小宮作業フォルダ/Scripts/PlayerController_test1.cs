using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController_test_1 : MonoBehaviour
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
        // カーソルを消す
        Cursor.visible = false;
        // カーソルをウィンドウから出さない
        Cursor.lockState = CursorLockMode.Confined;
    }

    // ずっと実行される
    void Update()
    {
       Move();

       Attack();
       Camera. transform. position = transform. position;
    }

    void Move()// WASDの操作
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
