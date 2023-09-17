using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class StepCountButton : MonoBehaviour 
{
    public int PlayerExp;
    public static int PlayerLevel = 1;
    public InputField textInput;

    public Slider slider;

    void Start()
    {
        int PlayerExp = 0;
        int PlayerLevel = 1;
        slider.value = 0;
        textInput = textInput.GetComponent<InputField>();
    }

    void Update()
    {
        slider.value = PlayerExp/1000;
    }

    public void Click()
    {
        int input = int.Parse(textInput.text);
        PlayerExp += input;
        if (PlayerExp >= 1000)
        {
            PlayerLevel += PlayerExp/1000;
            PlayerExp = 0;
        }
        textInput.text = "";
    }

    public void EnemyDead()
    {
        PlayerExp += 200;
    }
}