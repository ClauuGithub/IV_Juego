using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : AGameState
{
    public GameOverState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOverScene"); // Carga tu escena de derrota

        if (MusicManager.instance != null)
        {
            MusicManager.instance.ChangeMusic(MusicManager.instance.menuMusic);
        }
    }
}