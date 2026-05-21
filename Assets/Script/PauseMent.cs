using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMent : MonoBehaviour
{
    public GameObject container;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
    }
    public void Resume()
    {
        container.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelMenu");
    }
    public void Restart()
    {
        AudioListener.pause = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("TestScene");
    }
}
