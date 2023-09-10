using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonClick : MonoBehaviour
{
    public StepCountButton stepCountButton;

    public void OnClick()
    {
        stepCountButton.Click();
    }
}
