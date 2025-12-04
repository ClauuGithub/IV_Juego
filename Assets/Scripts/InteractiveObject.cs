using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    void OnMouseEnter()
    {
        PlayerCursor.Instance.SetHover();
    }

    void OnMouseExit()
    {
        PlayerCursor.Instance.SetDefault();
    }

}
