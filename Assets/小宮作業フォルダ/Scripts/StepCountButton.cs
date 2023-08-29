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
    }

    public void OnClick()
    {
        int input = int.Parse(textInput.text);
        PlayerExp += input;
        slider.value = PlayerExp/1000;
    }
}