using UnityEngine;

public class CutSceneState : AGameState
{
    public CutSceneState(GameStateSingleton ctx) : base(ctx) { }

    public override void Enter()
    {
        // El estado de cinemática pincha su propia música
        if (MusicManager.instance != null)
        {
            MusicManager.instance.ChangeMusic(MusicManager.instance.cutSceneMusic);
        }
    }
}