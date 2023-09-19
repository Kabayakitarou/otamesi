using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public Text textUI;
    public Slider slider;

    void Update(){
        string StringText = StepCountButton.PlayerLevel.ToString();
        textUI.text = StringText;
        
        //int SliderValue = StepCountButton.SliderExp;
        slider.value = StepCountButton.SliderExp;
        
    }
}
