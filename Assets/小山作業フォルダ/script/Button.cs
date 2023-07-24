using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    
    public void Onclick()
    {
        SceneManager.LoadScene("GameScene1");
        
    }
}
