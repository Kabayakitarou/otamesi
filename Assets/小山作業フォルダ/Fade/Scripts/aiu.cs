using UnityEngine;
using UnityEngine.SceneManagement;

public class aiu : MonoBehaviour
{
    [SerializeField] Fade fade;

    public void Onclick()
    {
        fade.FadeIn(1f, () => SceneManager.LoadScene("GameScene1 1"));
    }
}
