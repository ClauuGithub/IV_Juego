using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryState : AGameState
{
    public VictoryState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        Time.timeScale = 0f; // Paramos el juego
        SceneManager.LoadScene("VictoryScene"); // Carga la pantalla de victoria

        if (MusicManager.instance != null)
        {
            MusicManager.instance.ChangeMusic(MusicManager.instance.menuMusic);
        }

    }
}