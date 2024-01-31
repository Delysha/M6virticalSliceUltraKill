using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void BackToMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
