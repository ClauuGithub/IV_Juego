using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStateSingleton;

// corre el tiempo y controla si el jugador pierde.
public class PlayingState : AGameState
{
    public PlayingState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        // 1. Devolvemos el tiempo del motor a la normalidad (¡vuelve a la vida!)
        Time.timeScale = 1f;
        context.isPaused = false;

        // SOLO cargamos la escena si la escena actual NO es ya la escena a la que queremos ir
        if (!string.IsNullOrEmpty(context.lastGameScene) && SceneManager.GetActiveScene().name != context.lastGameScene)
        {
            SceneManager.LoadScene(context.lastGameScene);
        }

        // ¡IMPORTANTE! Limpiamos el rastro para que no se quede en bucle al reanudar
        context.lastGameScene = "";
    }

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