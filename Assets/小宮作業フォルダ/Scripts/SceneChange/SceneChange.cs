using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneChange: MonoBehaviour 
{
    //GameScene1 to StepCount
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("StepCount");
    }
}
