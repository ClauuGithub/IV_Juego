using UnityEngine;
using UnityEngine.SceneManagement;

public class BalconyUnlock : MonoBehaviour
{
    //cuando se hace click en el balcón
    void OnMouseDown()
    {
        //se ha tenido que resolver el código primero
        if (GameStateSingleton.Instance.currentState >= GameStateSingleton.GameState.BalconyUnlocked)
        {
            SceneManager.LoadScene("BalconyPuzzle");
        }
        else
        {
            MessageManager.Instance.ShowMessage("Podría entrar por ahí... Si llegase, claro.", 5f);
        }


    }
}
