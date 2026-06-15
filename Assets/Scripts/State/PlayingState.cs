using UnityEngine;
using static GameStateSingleton;

// corre el tiempo y controla si el jugador pierde.
public class PlayingState : AGameState
{
    public PlayingState(GameStateSingleton ctx) : base(ctx) { }

    public override void Update()
    {
        // El tiempo solo baja si estamos en este estado
        context.currentTime -= Time.deltaTime;

        if (context.currentTime <= 0)
        {
            context.currentTime = 0;
            // Transición automática al estado de derrota
            context.SetState(new GameOverState(context));
        }

        // Control del aviso del parpadeo
        context.isWarningActive = (context.currentTime <= context.warningTime);
    }
}