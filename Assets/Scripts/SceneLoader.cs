using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStateSingleton;

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

    public void PrevMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void MenuScene()
    {
        //GameStateSingleton.Instance.ResetGameState();
        SceneManager.LoadScene("MenuScene");
    }
    public void StartNewGame()
    {
        if (GameStateSingleton.Instance != null)
        {
            GameStateSingleton.Instance.ResetGameState();
            GameStateSingleton.Instance.currentState = GameState.SearchingKey;
        }
        Level1MainScene();
    }

    public void Level1MainScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Level2MainScene()
    {
        SceneManager.LoadScene("GameScene2");
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

    public void CreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void ExitGame()
    {
        Application.Quit();

        // Para ver que funciona mientras se prueba dentro de Unity
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }


}

