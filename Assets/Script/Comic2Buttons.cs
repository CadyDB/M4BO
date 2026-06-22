using UnityEngine;
using UnityEngine.SceneManagement;

public class Comic2Buttons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }
}
