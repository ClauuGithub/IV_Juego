using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // El nombre de la escena se introduce en el editor de Unity
    public void PauseScene()
    {
        SceneManager.LoadScene("PauseScene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void MenuScene()
    {
        GameStateSingleton.Instance.ResetGameState();
        SceneManager.LoadScene("MenuScene");
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

    public void RankingScene()
    {
        SceneManager.LoadScene("RankingScene");
    }
}

