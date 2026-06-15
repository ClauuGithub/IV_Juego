using UnityEngine;

public interface IState
{
    void Enter();   // Qué pasa al activar el estado
    void Update();  // Qué pasa frame a frame
    void Exit();    // Qué pasa al salir del estado
}