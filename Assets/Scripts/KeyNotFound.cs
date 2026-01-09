using UnityEngine;
using TMPro;
using System.Collections;

public class KeyNotFound : MonoBehaviour
{
    public TextMeshProUGUI message;
    public TextMeshProUGUI hideOtherMessage;

    private float messageDuration = 3.5f;

    void OnMouseDown()
    {
        if (message == null) return;

        // Añadir el mensaje TMP en el editor
        message.gameObject.SetActive(true);
        hideOtherMessage.gameObject.SetActive(false);

        StopAllCoroutines();
        StartCoroutine(HideMessageAfterTime());
    }

    IEnumerator HideMessageAfterTime()
    {
        yield return new WaitForSeconds(messageDuration);
        message.gameObject.SetActive(false);
    }
}
