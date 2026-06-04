using UnityEngine;

public class StatuePedestal : MonoBehaviour
{
    public string correctStatueID;

    private bool occupied = false;

    private void OnMouseDown()
    {
        if (occupied)
            return;

        string carried = GameStateSingleton.Instance.carriedStatue;

        if (string.IsNullOrEmpty(carried))
            return;

        occupied = true;

        if (carried == correctStatueID)
        {
            Debug.Log("Correcto");
            PuzzleManager.Instance.AddCorrectStatue();
        }
        else
        {
            Debug.Log("Incorrecto");
        }

        GameStateSingleton.Instance.carriedStatue = "";
    }
}
