using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToGameScene1 : MonoBehaviour
{
    [SerializeField] Fade fade;

    public void Onclick()
    {
        fade.FadeIn(1f, () => SceneManager.LoadScene("GameScene1"));
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
