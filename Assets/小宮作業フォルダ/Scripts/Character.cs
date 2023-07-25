using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    
    void Awake()
    {
        //コンポーネントと関連付け
        TryGetComponent(out animator);
    }
    
    void Start()
    {
        //カーソルを中央に固定
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //入力を取得
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        var leftStick = new Vector3(inputX, 0, inputY).normalized;

        //移動速度を計算
        var velocity = speed * leftStick;
    }
}
