using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public StepCountButton stepCountButton;
    public Text textUI;

    void Update()
    {
        stepCountButton = GameObject.Find("UIStatusManager").GetComponent<StepCountButton>();
        textUI.text = stepCountButton.PlayerLevel.ToString();
    }
}
