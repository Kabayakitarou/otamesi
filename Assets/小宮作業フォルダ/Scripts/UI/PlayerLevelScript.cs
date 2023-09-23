using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelScript : MonoBehaviour
{
    public Text textUI;
    public Text PlayerEXPtext;
    public static PlayerLevelScript instance;

    private void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    void Update(){
        PlayerEXPtext.text = StepCountButton.PlayerExp + " / " + StepCountButton.PlayerLevel*1000;
    }

    public void LevelUp(){
        string StringText = StepCountButton.PlayerLevel.ToString();
        textUI.text = StringText;
    }
}
