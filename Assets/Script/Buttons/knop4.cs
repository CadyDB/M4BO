using UnityEngine;
using UnityEngine.SceneManagement;

public class knop4 : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level4");
        Time.timeScale = 1;
    }
}
