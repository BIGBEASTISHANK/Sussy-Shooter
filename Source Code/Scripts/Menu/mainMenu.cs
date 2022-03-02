using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuGO, controllsGO;

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/Level 1");
    }

    public void Controlls()
    {
        mainMenuGO.SetActive(false);
        controllsGO.SetActive(true);
    }

    public void ControllsGoBack()
    {
        controllsGO.SetActive(false);
        mainMenuGO.SetActive(true);
    }

    public void QuitGame() { Application.Quit(); }
}