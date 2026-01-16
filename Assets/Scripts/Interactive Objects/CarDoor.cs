using UnityEngine;

public class CarDoor : MonoBehaviour
{
    //[SerializeField] private string requiredKey = "CarKey"; // La llave necesaria

    private void OnMouseDown()
    {
        if (GameStateSingleton.Instance.HasKey("CarKey"))
        {
            // La puerta se puede abrir
            MessageManager.Instance.ShowMessage("La puerta se abre", 5f);
            // Aquí podrías llamar a un método OpenDoor() si quieres animación
        }
        else
        {
            // Todavía no tienes la llave
            MessageManager.Instance.ShowMessage("Está cerrada, necesito la llave", 5f);
        }
    }
}
