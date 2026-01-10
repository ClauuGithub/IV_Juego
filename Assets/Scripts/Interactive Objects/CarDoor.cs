using TMPro;
using UnityEngine;
using System.Collections;

public class CarDoor : MonoBehaviour
{
    public TextMeshProUGUI message;
    public TextMeshProUGUI lockMessage;

    private float hideDelay = 5f;
    void OnMouseDown()
    {
        if (GameStateSingleton.Instance.HasKey("CarKey"))   // indica que llave necesita
        {
            //OpenDoor();
            message.gameObject.SetActive(true);
        }
        else
        {
            //ShowLockedMessage();
            lockMessage.gameObject.SetActive(true);
        }

        StartCoroutine(HideMessageAfterTime());
    }

    //Espera unos segundos para ocultar el mensaje y la llave
    IEnumerator HideMessageAfterTime()
    {
        yield return new WaitForSeconds(hideDelay);

        if (message != null)
            message.gameObject.SetActive(false);
    }
}
