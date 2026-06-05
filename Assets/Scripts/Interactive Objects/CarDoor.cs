using UnityEngine;
using UnityEngine.SceneManagement;

// Ejemplo claro de PATTERN STATE aplicado
public class CarDoor : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Se ha tenido que encontrar la llave primero
        if (GameStateSingleton.Instance.currentState >= GameStateSingleton.GameState.KeyFound)
        {
            MessageManager.Instance.ShowMessage("¡He conseguido arrancar el motor!", 5f );

            GameStateSingleton.Instance.currentState = GameStateSingleton.GameState.CarUnlocked;
        }
        else
        {
            MessageManager.Instance.ShowMessage("Si dejaran las llaves puestas sería demasiado fácil.", 5f);
        }
    }
}