using UnityEngine;

// Esta clase abstracta sirve para que todos los estados tengan una referencia directa a tu GameStateSingleton y puedan modificar el tiempo o las variables:
public abstract class AGameState : IState
{
    protected GameStateSingleton context;

    public AGameState(GameStateSingleton ctx)
    {
        context = ctx;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}