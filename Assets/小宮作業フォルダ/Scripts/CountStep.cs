using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CountStep : MonoBehaviour
{
    InputField inputField;

    void Start()
    {
        int inputField = int.Parse(GetComponent<InputField>().text);

        StatusManager script = new StatusManager();
        script.GetSetProperty = inputField;
    }
}
