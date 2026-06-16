using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : AGameState
{
    public MainMenuState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        SceneManager.LoadScene("MenuScene");

        // El estado del menú se encarga de decirle al MusicManager qué tocar
        if (MusicManager.instance != null)
        {
            MusicManager.instance.ChangeMusic(MusicManager.instance.menuMusic);
        }
    }
}