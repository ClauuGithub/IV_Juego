using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderUnlock : MonoBehaviour
{ 
    //cuando se hace click en la parte de abajo de la escalera
    void OnMouseDown()
    {
        //se ha tenido que abrir el coche primero
        if (GameStateSingleton.Instance.carUnlocked)
        {
            SceneManager.LoadScene("PuzzleCodigo");
        }
        else
        {
            MessageManager.Instance.ShowMessage("La escalera no funciona si el coche no está arrancado", 5f);
        }

           
    }
}
