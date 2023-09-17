using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeWalkingToEnter : MonoBehaviour
{
    public void OnClick(){
        SceneManager.LoadScene("enter");
    }
}
