using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeEnterToGame1: MonoBehaviour {

      
      public void change_button()
    {
        SceneManager.LoadScene("GameScene1");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
