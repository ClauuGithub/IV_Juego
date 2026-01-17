using UnityEngine;
using UnityEngine.SceneManagement;

public class BalconyUnlock : MonoBehaviour
{
    //cuando se hace click en la parte de abajo de la escalera
    void OnMouseDown()
    {
        //se ha tenido que abrir el coche primero para desbloquear este puzzle
        if (GameStateSingleton.Instance.codeSolved)
        {
            SceneManager.LoadScene("GameScene2");
        }
        else
        {
            MessageManager.Instance.ShowMessage("Podría entrar por ahí... si llegase claro", 5f);
        }


    }
}
