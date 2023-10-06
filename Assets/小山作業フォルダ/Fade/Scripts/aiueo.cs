using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class aiueo : MonoBehaviour
{
    public static int score_num = 0;
    public static string AAA = "";
    
    
    

    public void Onclick()
    {
        
        SceneManager.LoadScene("time");
        string AAA = score_num.ToString();
        AAA =  "time" + Time.time;


    }
}

