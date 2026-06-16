using UnityEngine;

public class StatuePedestal : MonoBehaviour
{
    public string correctStatueID;
    public GameObject statueVisual;

    private bool occupied = false;

    [TextArea]
    public string clueText;

    private void Start()
    {
        Debug.Log(GameStateSingleton.Instance);

        if (GameStateSingleton.Instance.placedStatues.Contains(correctStatueID))
        {
            occupied = true;
            statueVisual.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        // Mostrar pista siempre
        MessageManager.Instance.ShowMessage(clueText);

        if (occupied)
            return;

        string carried = GameStateSingleton.Instance.carriedStatue;

        if (string.IsNullOrEmpty(carried))
            return;

        // Comprobar que es la estatua correcta
        if (carried == correctStatueID)
        {
            MessageManager.Instance.ShowMessage("¡Perfecto!");
            occupied = true;
            statueVisual.SetActive(true);

            GameStateSingleton.Instance.placedStatues.Add(carried);

            GameStateSingleton.Instance.carriedStatue = "";

            Debug.Log("Estatua correcta.");

            if (GameStateSingleton.Instance.placedStatues.Count >= 3)
            {
                MessageManager.Instance.ShowMessage("He resuelto el enigma de los dioses. La puerta a la siguiente sala debe de estar abierta de nuevo.", 3f);
                Debug.Log("Puzzle completado");

                GameStateSingleton.Instance.currentPuzzle =
                    GameStateSingleton.Progress.GodsPuzzleSolved;
            }
        }
        else
        {
            MessageManager.Instance.ShowMessage("Hmmm... Este no es su sitio.");
            Debug.Log("Estatua incorrecta.");
        }
    }
}