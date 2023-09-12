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
        textInput = textInput.GetComponent<InputField>();

        int PlayerExp = 0;
        slider.value = 0;
    }

    void Update()
    {
        slider.value = PlayerExp/1000;
    }

    public void Click()
    {
        int input = int.Parse(textInput.text);
        PlayerExp += input;
        if (PlayerExp > 1000){
            PlayerExp = 0;
            PlayerLevel += 1;
        }
    }
}