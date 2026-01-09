using UnityEngine;
using TMPro;
using System.Collections;

public class KeyNotFound : MonoBehaviour
{
    public TextMeshProUGUI message;
    public float messageDuration = 3f;

    void OnMouseDown()
    {
        if (message == null) return;

        message.gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(HideMessageAfterTime());
    }

    IEnumerator HideMessageAfterTime()
    {
        yield return new WaitForSeconds(messageDuration);
        message.gameObject.SetActive(false);
    }
}
