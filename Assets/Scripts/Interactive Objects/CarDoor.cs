using UnityEngine;
using UnityEngine.SceneManagement;

public class CarDoor : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Se ha tenido que encontrar la llave primero
        if (GameStateSingleton.Instance.currentPuzzle >= GameStateSingleton.Progress.KeyFound)
        {
            MessageManager.Instance.ShowMessage("¡He conseguido arrancar el motor!", 5f );

            GameStateSingleton.Instance.currentPuzzle = GameStateSingleton.Progress.CarUnlocked;
        }
        else
        {
            MessageManager.Instance.ShowMessage("Si dejaran las llaves puestas sería demasiado fácil.", 5f);
        }
    }
}