using UnityEngine;

public class CarDoor : MonoBehaviour
{
    //cuando se hace click en la puerta del coche
    private void OnMouseDown()
    {
        if (GameStateSingleton.Instance.HasKey("CarKey")) //llave obtenida
        {
            MessageManager.Instance.ShowMessage("¡He conseguido arrancar el motor!", 5f);
            GameStateSingleton.Instance.carUnlocked = true;  // el estado de la puerta cambia a true, desbloquea el siguiente puzzle
        }
        else
        {
            // Todavía no tienes la llave
            MessageManager.Instance.ShowMessage("Si dejaran las llaves puestas sería demasiado fácil", 5f);
        }
    }
}
