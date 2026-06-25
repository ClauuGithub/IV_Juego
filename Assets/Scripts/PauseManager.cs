using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    // Guardamos aquí la escena anterior para que los estados puedan leerla
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
        // SceneManager guarda la escena de la que venimos 
        lastGameScene = SceneManager.GetActiveScene().name;

        // Pasa al estado de pausa
        GameStateSingleton.Instance.SetState(new PauseState(GameStateSingleton.Instance));
    }

    // Vinculado al botón de Volver a la partida del Canvas de la escena de Pausa
    public void ResumeGame()
    {
        GameStateSingleton.Instance.SetState(new PlayingState(GameStateSingleton.Instance));
    }
}