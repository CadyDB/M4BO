using UnityEngine;
using UnityEngine.SceneManagement;

public class knop3 : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
        Time.timeScale = 1;
    }
}
