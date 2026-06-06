using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorUnlock : MonoBehaviour
{
    //cuando se hace click en la puerta
    void OnMouseDown()
    {
        // Se ha tenido que resolver el puzzle antes
        if (GameStateSingleton.Instance.currentState >= GameStateSingleton.GameState.GodsPuzzleSolved)
        {
            SceneManager.LoadScene("GameScene3");
        }
        else
        {
            MessageManager.Instance.ShowMessage("La puerta se ha cerrado con la corriente. Necesito encontrar una forma de abrirla...", 5f);
        }


    }
}
