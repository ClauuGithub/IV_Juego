using UnityEngine;
using TMPro;

public class KeyNotFound : MonoBehaviour
{
    public TextMeshProUGUI message;

    void OnMouseDown()
    {

        if (message != null)
        {
            // Añadir el mensaje TMP en el editor
            message.gameObject.SetActive(true);
        }
    }
}
