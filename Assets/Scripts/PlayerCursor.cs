using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
    public static PlayerCursor Instance;

    public Texture2D cursorDefault;
    public Texture2D cursorHover;
    public Texture2D cursorZoom;
    private Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        // Usa Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.Auto);
    }

    void Update()
    {
        // Posicion en el mundo
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 screenPos = new Vector3(mousePos.x, mousePos.y, 10f); // Z = distancia cámara, plano 0
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        transform.position = worldPos;

        // Raycast para detectar objetos con collider
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        if (hit.collider != null)
        {
            switch (hit.collider.tag)
            {
                case "Interactive":
                    Cursor.SetCursor(cursorHover, hotSpot, CursorMode.Auto);
                    break;
                case "Zoom":
                    Cursor.SetCursor(cursorZoom, hotSpot, CursorMode.Auto);
                    break;
                default:
                    Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.Auto);
                    break;
            }

        }
        else
        {
            Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.Auto);
        }
    }
}
