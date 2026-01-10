using UnityEngine;
using TMPro;
using System.Collections;

public class KeyFound : MonoBehaviour
{
    public GameObject overlap;                 // sprite que tapa la llave
    public TextMeshProUGUI message;            
    public TextMeshProUGUI hideOtherMessage;  
    
    private float hideDelay = 5f;
    private bool picked = false;

    void OnMouseDown()
    {
        if (picked) return;
        picked = true;

        // Oculta el overlap
        if (overlap != null)
            overlap.SetActive(false);

        // Oculta otros mensajes
        if (hideOtherMessage != null)
            hideOtherMessage.gameObject.SetActive(false);

        if (message != null)
            message.gameObject.SetActive(true);

        StartCoroutine(HideMessageAfterTime());
    }

    IEnumerator HideMessageAfterTime()
    {
        yield return new WaitForSeconds(hideDelay);
        if (message != null)
            message.gameObject.SetActive(false);

        // Oculta la llave
        gameObject.SetActive(false);
    }
}
