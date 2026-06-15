using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryState : AGameState
{
    public VictoryState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        Time.timeScale = 0f; // Paramos el juego
        context.RegisterFinishTime(); // Registra el tiempo en tu Dirty Flag
        GameStateSingleton.Instance.SetState(new VictoryState(GameStateSingleton.Instance));
        SceneManager.LoadScene("VictoryScene"); // Carga la pantalla de victoria
    }
}