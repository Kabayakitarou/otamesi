using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class StepCountButton : MonoBehaviour 
{
    public float PlayerExp;
    public int PlayerLevel;
    public InputField textInput;

    public Slider slider;

    void Start()
    {
        float PlayerExp = 0;
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
        if (PlayerExp > 1000)
        {
            PlayerExp -= PlayerLevel*1000;
            PlayerLevel += 1;
        }
    }

    public void EnemyDead()
    {
        PlayerExp += 200;
    }
}