using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneChange1: MonoBehaviour 
{
    //StepCount to GameScene1
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("GameScene1");
    }
}
