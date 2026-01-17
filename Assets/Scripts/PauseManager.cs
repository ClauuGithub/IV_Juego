using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    private string lastGameScene; // para guardar en qué escena se estaba antes de pausar

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Resumir juego
    public void PauseGame()
    {
        lastGameScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;
        GameStateSingleton.Instance.isPaused = true;
        SceneManager.LoadScene("PauseScene");
    }

    // Reanudar juego
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameStateSingleton.Instance.isPaused = false;
        SceneManager.LoadScene(lastGameScene);
    }
}