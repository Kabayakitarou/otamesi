using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using UnityEngine.UI;  
 
public class timer : MonoBehaviour {
 
 
    public GameObject score_object ; 
 
      
      void Start () {
      }
 
      
      void Update () {
        
        Text score_text = score_object.GetComponent<Text> ();
        
        score_text.text = "time:" + Time.time;
      }
}