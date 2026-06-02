using UnityEngine;

// Ejemplo claro de PATTERN STATE aplicado
public class CarDoor : MonoBehaviour
{
    private void OnMouseDown()
    {
        switch (GameStateSingleton.Instance.currentState)
        {
            // =========================
            // NO TIENES NADA
            // =========================
            case GameStateSingleton.GameState.SearchingKey:

                MessageManager.Instance.ShowMessage(
                    "Si dejaran las llaves puestas sería demasiado fácil",
                    5f
                );
                break;

            // =========================
            // TIENES LA LLAVE Y SE USA EL COCHE
            // =========================
            case GameStateSingleton.GameState.KeyFound:

                MessageManager.Instance.ShowMessage(
                   "¡He conseguido arrancar el motor!",
                   5f
               );

                // transición de estado
                GameStateSingleton.Instance.currentState =
                    GameStateSingleton.GameState.CarUnlocked;

                break;

            // =========================
            // YA ESTÁ DESBLOQUEADO
            // =========================
            case GameStateSingleton.GameState.CarUnlocked:

                // De momento no hay nada, lo dejo así por si hay que añadir cosas
               
                break;
        }
    }
}