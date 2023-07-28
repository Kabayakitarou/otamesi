using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] Fade fade;

    public void Onclick()
    {
        fade.FadeIn(1f, () => SceneManager.LoadScene("GameScene1 1"));
    }
}
