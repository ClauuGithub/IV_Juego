using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : AGameState
{
    public PauseState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        context.lastGameScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f; // Congela el motor de Unity (animaciones, físicas, etc.)
        context.isPaused = true;
        SceneManager.LoadScene("PauseScene");
    }

    public override void Exit()
    {
        Time.timeScale = 1f; // Devuelve el juego a la normalidad al salir de la pausa
        context.isPaused = false;
    }
}