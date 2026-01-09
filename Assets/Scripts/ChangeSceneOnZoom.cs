using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnZoom : MonoBehaviour
{
    public string sceneName; // se escribe manualmente en el editor

    public void OnClick()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}