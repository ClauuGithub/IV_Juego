using UnityEngine;
using UnityEngine.SceneManagement;

// NO USADO AÚN
public class GlobalSceneLoader : MonoBehaviour
{
    public static GlobalSceneLoader Instance;

    // Usa Singleton para tener un único manager para todas las escenas
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // El nombre de la escena se introduce manualmente en el editor de Unity
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Aquí podemos meter métodos para recargar escenas con singleton 
}
