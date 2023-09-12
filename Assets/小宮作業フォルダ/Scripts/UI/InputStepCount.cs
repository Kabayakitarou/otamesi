using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class InputStepCount : MonoBehaviour 
{
    public GameObject StepCount;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            GetStepCount();
        }
    }

    void GetStepCount()
    {
        if(StepCount.activeInHierarchy)
        {
            StepCount.SetActive(false);
            Cursor.visible = false;
        }
        else
        {
            StepCount.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

    }
}