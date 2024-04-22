using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }
    public bool IsPaused { get; private set; }

    [SerializeField] private GameObject _pauseMenu;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Pause()
    {
        IsPaused = true;
        _pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Unpause()
    {
        IsPaused = false;
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void MainMenuUnpause()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
