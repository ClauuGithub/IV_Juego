using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    public static PlayerCursor Instance;

    public Texture2D defaultCursor;
    public Texture2D hoverCursor;

    private Vector2 hotspot = Vector2.zero;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    public void SetDefault()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    public void SetHover()
    {
        Cursor.SetCursor(hoverCursor, hotspot, CursorMode.Auto);
    }
}
