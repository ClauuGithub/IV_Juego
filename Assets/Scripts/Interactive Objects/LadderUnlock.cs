using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderUnlock : MonoBehaviour
{
    //cuando se hace click en la parte de abajo de la escalera
    void OnMouseDown()
    {
        // Se ha tenido que abrir el coche primero
        if (GameStateSingleton.Instance.currentPuzzle >= GameStateSingleton.Progress.CarUnlocked)
        {
            SceneManager.LoadScene("PuzzleCodigo");
        }
        else
        {
            MessageManager.Instance.ShowMessage("La escalera no funciona si el coche no está arrancado.", 5f);
        }
    }

}
