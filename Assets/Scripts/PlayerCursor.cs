using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
    public static PlayerCursor Instance;

    public Texture2D cursorDefault;
    public Texture2D cursorHover;
    private Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Cursor por defecto al inicio
        Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.Auto);
    }

    void Update()
    {
        // Obtener posición del ratón en el mundo
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Raycast para detectar objetos con collider
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        if (hit.collider != null)
        {
            Cursor.SetCursor(cursorHover, hotSpot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.Auto);
        }
    }

    // Métodos públicos para que otros scripts puedan cambiar el cursor manualmente
    public void SetDefault() => Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.Auto);
    public void SetHover() => Cursor.SetCursor(cursorHover, hotSpot, CursorMode.Auto);
}
