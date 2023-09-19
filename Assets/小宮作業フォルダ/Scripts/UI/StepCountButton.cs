using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class StepCountButton : MonoBehaviour 
{
    public static int PlayerExp = 0;
    public static int SliderExp = 0;
    public static int PlayerLevel = 0;

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
            PlayerLevel = PlayerExp/1000;
            Debug.Log(PlayerLevel);
            Debug.Log(PlayerExp);
        }
        int SliderExp = PlayerExp - PlayerLevel*1000;
        Debug.Log(SliderExp);
        textInput.text = "";
    }

    public void EnemyDead()
    {
        PlayerExp += 200;
    }
}