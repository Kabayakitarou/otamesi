using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneChange: MonoBehaviour 
{
    void Update(){
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("enter");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
