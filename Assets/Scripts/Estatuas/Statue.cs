using UnityEngine;
using UnityEngine.InputSystem;

public class Statue : MonoBehaviour
{
    public string statueID;

    private void Start()
    {
        if (GameStateSingleton.Instance.collectedStatues.Contains(statueID))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(GameStateSingleton.Instance);
        // Ya llevas una estatua
        if (GameStateSingleton.Instance.carriedStatue != "")
            return;

        // Guardamos qué estatua llevamos
        GameStateSingleton.Instance.carriedStatue = statueID;

        GameStateSingleton.Instance.collectedStatues.Add(statueID);

        Debug.Log("Recogida estatua: " + statueID);

        // La quitamos de la escena
        gameObject.SetActive(false);
    }
}
