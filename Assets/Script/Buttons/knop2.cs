using UnityEngine;
using UnityEngine.SceneManagement;

public class knop2 : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }
}
