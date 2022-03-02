using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject inGame, controlls, pause, mainPause;

    public void Controll()
    {
        mainPause.SetActive(false);
        controlls.SetActive(true);
    }

    public void controllsGoBack()
    {
        controlls.SetActive(false);
        mainPause.SetActive(true);
    }

    public void Resume()
    {
        pause.SetActive(false);
        inGame.SetActive(true);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}