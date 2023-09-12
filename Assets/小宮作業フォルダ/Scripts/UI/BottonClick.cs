using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonClick : MonoBehaviour
{
    public StepCountButton stepCountButton;

    void Start()
    {
        stepCountButton.PlayerExp = 0;
    }

    public void OnClick()
    {
        stepCountButton.Click();
    }
}
