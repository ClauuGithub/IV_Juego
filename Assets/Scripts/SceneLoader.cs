using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStateSingleton;

public class SceneLoader : MonoBehaviour
{
    // Los métodos se llaman en el editor de Unity
    public void PauseScene()
    {
        // Cambia al estado de pausa
        GameStateSingleton.Instance.SetState(new PauseState(GameStateSingleton.Instance));
    }

    public void LoadGameScene()
    {
        // Cambia al estado de cinemática 
        GameStateSingleton.Instance.SetState(new CutSceneState(GameStateSingleton.Instance));
        SceneManager.LoadScene("CutScene");
    }

    public void PrevMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void MenuScene()
    {
        GameStateSingleton.Instance.SetState(new MainMenuState(GameStateSingleton.Instance));

    }

    // ==========================================
    // BOTONES AFECTADOS POR EL PATRÓN STATE
    // ==========================================

    // Reset del juego al volver a empezar, tras la primera cinemática
    public void StartNewGame()
    {
        if (GameStateSingleton.Instance != null)
        {
            GameStateSingleton.Instance.ResetGameState();
            // Indicamos que el puzle inicial es buscar la llave
            GameStateSingleton.Instance.currentPuzzle = Progress.SearchingKey;

            // ACTIVAR EL PATRÓN STATE: El juego se pone en modo "Jugando"
            GameStateSingleton.Instance.SetState(new PlayingState(GameStateSingleton.Instance));
        }
        Level1MainScene();
    }

    public void ResumeGame()
    {
        // Cambia al estado jugando
        GameStateSingleton.Instance.SetState(new PlayingState(GameStateSingleton.Instance));
    }

    public void Level1MainScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Level2MainScene()
    {
        GameStateSingleton.Instance.SetState(new PlayingState(GameStateSingleton.Instance));
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

