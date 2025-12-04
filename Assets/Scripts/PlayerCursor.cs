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
        // Usa Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.Auto);
    }

    void Update()
    {
        //Obtiene la posición del ratón en el mundo
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 screenPos = new Vector3(mousePos.x, mousePos.y, 10f); // Z = distancia cámara ? plano 0
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        transform.position = worldPos;

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

    // Métodos públicos para que otros scripts puedan cambiar el cursor 
    public void SetDefault() => Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.Auto);
    public void SetHover() => Cursor.SetCursor(cursorHover, hotSpot, CursorMode.Auto);
}
