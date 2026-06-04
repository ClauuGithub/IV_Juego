using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public int totalStatues = 3;
    private int correctPlaced = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddCorrectStatue()
    {
        correctPlaced++;

        if (correctPlaced >= totalStatues)
        {
            Debug.Log("Puzzle completado");

            GameStateSingleton.Instance.currentState =
                GameStateSingleton.GameState.GodsPuzzleSolved;
        }
    }
}