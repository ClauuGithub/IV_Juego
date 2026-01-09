using UnityEngine;
using TMPro;

public class CraneKeyFound : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject overlap;        // sprite que tapa la llave
    public TextMeshProUGUI message;  

    private bool picked = false;

    void OnMouseDown()
    {
        if (picked) return;

        picked = true;

        // Oculta el overlap
        if (overlap != null)
            overlap.SetActive(false);

        if (message != null)
        {
            message.text = "¿De dónde será esta llave?";
            message.gameObject.SetActive(true);
        }
    }
}
