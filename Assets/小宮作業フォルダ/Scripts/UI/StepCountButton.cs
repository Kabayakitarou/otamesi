using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class StepCountButton : MonoBehaviour 
{
    public static int PlayerExp = 0;
    public static int PlayerLevel = 1;

    public InputField textInput;

    void Start()
    {
        textInput = textInput.GetComponent<InputField>();
    }

    public void Click()
    {
        int input = int.Parse(textInput.text);
        PlayerExp += input;
        if (PlayerExp >= 1000*PlayerLevel)
        {
            PlayerLevel = PlayerExp/1000 + 1;
            PlayerStatusManager.instance.HP = PlayerLevel*100;
            Debug.Log(PlayerStatusManager.instance.HP);
            PlayerLevelScript.instance.LevelUp();
        }
        textInput.text = "";

        string textstring = null;
        if(string.IsNullOrEmpty(textstring)){
            textInput.text = "";
        }
    }
    
}