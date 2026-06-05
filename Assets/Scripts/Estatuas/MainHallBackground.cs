using UnityEngine;

public class MainHallBackground : MonoBehaviour
{
    public GameObject fondoPuertaCerrada;
    public GameObject fondoPuertaAbierta;

    private void Start()
    {
        ActualizarFondo();
    }

    private void ActualizarFondo()
    {
        switch (GameStateSingleton.Instance.currentState)
        {
            case GameStateSingleton.GameState.GodsPuzzleSolved:

                fondoPuertaCerrada.SetActive(false);
                fondoPuertaAbierta.SetActive(true);
                break;

            default:

                fondoPuertaCerrada.SetActive(true);
                fondoPuertaAbierta.SetActive(false);
                break;
        }
    }
}
