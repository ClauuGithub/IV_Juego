using UnityEngine;

public class StatuePedestal : MonoBehaviour
{
    public string correctStatueID;

    [Header("Imagen que aparecerá")]
    public SpriteRenderer statueImageRenderer;

    public Sprite statueSprite;

    private bool occupied = false;

    private void Start()
    {
        Debug.Log(GameStateSingleton.Instance);

        if (GameStateSingleton.Instance.placedStatues.Contains(correctStatueID))
        {
            statueImageRenderer.sprite = statueSprite;
            statueImageRenderer.enabled = true;
            occupied = true;
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

            statueImageRenderer.sprite = statueSprite;
            statueImageRenderer.enabled = true;

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