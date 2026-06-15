using UnityEngine;

public class PauseState : AGameState
{
    public PauseState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        Time.timeScale = 0f; // Congela el motor de Unity (animaciones, físicas, etc.)
        context.isPaused = true;
    }

    public override void Exit()
    {
        Time.timeScale = 1f; // Devuelve el juego a la normalidad al salir de la pausa
        context.isPaused = false;
    }
}