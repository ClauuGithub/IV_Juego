using UnityEngine;

public class CarDoor : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameStateSingleton.Instance.HasKey("CarKey")) //llave obtenida
        {
            MessageManager.Instance.ShowMessage("¡Se ha abierto", 5f);
        }
        else
        {
            // Todavía no tienes la llave
            MessageManager.Instance.ShowMessage("Si dejaran las llaves puestas sería demasiado fácil", 5f);
        }
    }
}
