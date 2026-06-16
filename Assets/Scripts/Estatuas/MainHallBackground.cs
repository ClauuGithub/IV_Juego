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
        switch (GameStateSingleton.Instance.currentPuzzle)
        {
            case GameStateSingleton.Progress.GodsPuzzleSolved:

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
