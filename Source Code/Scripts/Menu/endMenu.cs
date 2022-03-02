using UnityEngine;
using UnityEngine.SceneManagement;

public class endMenu : MonoBehaviour
{
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void goBack()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }
}