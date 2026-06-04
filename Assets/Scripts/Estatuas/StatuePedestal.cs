using UnityEngine;

public class StatuePedestal : MonoBehaviour
{
    public string correctStatueID;
    public GameObject statueVisual;

    private bool occupied = false;

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
        if (occupied)
            return;

        string carried = GameStateSingleton.Instance.carriedStatue;

        if (string.IsNullOrEmpty(carried))
            return;

        // Comprobar que es la estatua correcta
        if (carried == correctStatueID)
        {
            occupied = true;
            statueVisual.SetActive(true);

            GameStateSingleton.Instance.placedStatues.Add(carried);

            GameStateSingleton.Instance.carriedStatue = "";

            Debug.Log("Estatua correcta");

            if (GameStateSingleton.Instance.placedStatues.Count >= 4)
            {
                Debug.Log("Puzzle completado");

                GameStateSingleton.Instance.currentState =
                    GameStateSingleton.GameState.GodsPuzzleSolved;
            }
        }
        else
        {
            Debug.Log("Estatua incorrecta");
        }
    }
}