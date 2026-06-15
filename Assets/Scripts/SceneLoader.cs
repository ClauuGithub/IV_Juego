using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStateSingleton;

public class SceneLoader : MonoBehaviour
{
    // El nombre de la escena se introduce en el editor de Unity
    public void PauseScene()
    {
        // Mandamos el juego al estado de pausa. El estado se encargará de guardar la escena y cargar la pantalla.
        GameStateSingleton.Instance.SetState(new PauseState(GameStateSingleton.Instance));
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

    // ==========================================
    // BOTONES AFECTADOS POR EL PATRÓN STATE
    // ==========================================

    public void StartNewGame()
    {
        if (GameStateSingleton.Instance != null)
        {
            GameStateSingleton.Instance.ResetGameState();
            // Indicamos que el puzle inicial es buscar la llave
            GameStateSingleton.Instance.currentState = GameState.SearchingKey;
            // ACTIVAR EL PATRÓN STATE: El juego se pone en modo "Jugando"
            GameStateSingleton.Instance.SetState(new PlayingState(GameStateSingleton.Instance));
        }
        Level1MainScene();
    }

    public void ResumeGame()
    {
        // Mandamos el juego al estado jugando. El estado recordará a qué escena volver.
        GameStateSingleton.Instance.SetState(new PlayingState(GameStateSingleton.Instance));
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

