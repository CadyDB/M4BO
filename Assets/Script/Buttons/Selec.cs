using UnityEngine;
using UnityEngine.SceneManagement;

public class Selec : MonoBehaviour
{
    public void StoryMode()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StoryMenu");
        Time.timeScale = 1;
    }
    public void SongSelec()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelMenu");
        Time.timeScale = 1;
    }
    public void How2Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HowtoPlay");
        Time.timeScale = 1;
    }
    public void Lore()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lore");
        Time.timeScale = 1;
    }
    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeScene");
        Time.timeScale = 1;
    }
}
