using UnityEngine;
using UnityEngine.SceneManagement;

public class knop : MonoBehaviour
{
    public void ComicBook1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ComicBook1");
        Time.timeScale = 1;
    }
    public void ComicBook2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ComicBook2");
        Time.timeScale = 1;
    }
    public void ComicBook3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ComicBook3");
        Time.timeScale = 1;
    }
    public void ComicBook4()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ComicBook4");
        Time.timeScale = 1;
    }
    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Selectie");
        Time.timeScale = 1;
    }
    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }
    public void realselect()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Selectie");
        Time.timeScale = 1;
    }
}
