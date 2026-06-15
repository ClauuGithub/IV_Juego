using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    // Guardamos aquí la escena para que los estados puedan leerla
    [HideInInspector] public string lastGameScene;

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

    // Vinculado al botón de Pausa del Canvas del juego
    public void PauseGame()
    {
        // El mánager solo toma la foto de dónde estábamos...
        lastGameScene = SceneManager.GetActiveScene().name;

        // ...y le pasa el control total al patrón State
        GameStateSingleton.Instance.SetState(new PauseState(GameStateSingleton.Instance));
    }

    // Vinculado al botón de Reanudar del Canvas de la escena de Pausa
    public void ResumeGame()
    {
        // El mánager no hace nada más, el PlayingState se encargará de todo
        GameStateSingleton.Instance.SetState(new PlayingState(GameStateSingleton.Instance));
    }
}