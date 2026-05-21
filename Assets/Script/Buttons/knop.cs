using UnityEngine;
using UnityEngine.SceneManagement;

public class knop : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
}
