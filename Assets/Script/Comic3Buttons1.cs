using UnityEngine;
using UnityEngine.SceneManagement;

public class Comic3Buttons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
        Time.timeScale = 1;
    }
}
