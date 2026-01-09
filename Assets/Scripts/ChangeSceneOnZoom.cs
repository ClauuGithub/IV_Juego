using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnZoom : MonoBehaviour
{
    public string sceneName; //escribir manualmente el nombre de la escena en el editor de Unity

    void OnMouseDown() //click para collider2D
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
