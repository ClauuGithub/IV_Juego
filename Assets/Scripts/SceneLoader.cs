using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // El nombre de la escena se introduce manualmente en el editor de Unity
    public void PauseScene()
    {
        SceneManager.LoadScene("PauseScene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void Level1MainScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ConfigScene()
    {
        SceneManager.LoadScene("ConfigScene");
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

}

