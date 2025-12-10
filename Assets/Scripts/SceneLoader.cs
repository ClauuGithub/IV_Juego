using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // El nombre de la escena se introduce manualmente en el editor de Unity
    public void PauseScene()
    {
        SceneManager.LoadScene("PauseScene");
    }
}
