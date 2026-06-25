using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : AGameState
{
    public MainMenuState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        SceneManager.LoadScene("MenuScene");

        if (MusicManager.instance != null)
        {
            MusicManager.instance.ChangeMusic(MusicManager.instance.menuMusic);
        }
    }
}