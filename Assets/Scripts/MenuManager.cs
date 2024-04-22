using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ResetButton()
    {
        PauseManager.Instance.Unpause();
        int toLoad = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(toLoad);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (PauseManager.Instance.IsPaused == true)
        {
            PauseManager.Instance.Unpause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void MainMenuButton()
    {
        string toLoad = "MainMenu";

        if (PauseManager.Instance.IsPaused == true)
        {
            PauseManager.Instance.MainMenuUnpause();
            SceneManager.LoadScene(toLoad);
        }
        else
        {
            SceneManager.LoadScene(toLoad);
        }
    }
}
