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

            Debug.Log("Estatua correcta");

            if (GameStateSingleton.Instance.placedStatues.Count >= 3)
            {
                MessageManager.Instance.ShowMessage("He resuleto el enigma de los dioses. La puerta a la siguiente sala debe de volver a estar abierta", 3f);
                Debug.Log("Puzzle completado");

                GameStateSingleton.Instance.currentState =
                    GameStateSingleton.GameState.GodsPuzzleSolved;
            }
        }
        else
        {
            MessageManager.Instance.ShowMessage("Hmmm este no es su sitio");
            Debug.Log("Estatua incorrecta");
        }
    }
}