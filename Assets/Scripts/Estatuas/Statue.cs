using UnityEngine;
using UnityEngine.InputSystem;

public class Statue : MonoBehaviour
{
    public string statueID;

    private void OnMouseDown()
    {
        // Ya llevas una estatua
        if (GameStateSingleton.Instance.carriedStatue != "")
            return;

        // Guardamos qué estatua llevamos
        GameStateSingleton.Instance.carriedStatue = statueID;

        Debug.Log("Recogida estatua: " + statueID);

        // La quitamos de la escena
        gameObject.SetActive(false);
    }
}
