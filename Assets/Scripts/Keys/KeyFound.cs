using UnityEngine;
using TMPro;
using System.Collections;

public class KeyFound : MonoBehaviour
{
    public GameObject overlap;                  // sprite que tapa la llave
    /*public TextMeshProUGUI message;
    public TextMeshProUGUI hideOtherMessage;*/

    private string keyId = "CarKey";            // indicarle un id para el Singleton
    private float hideDelay = 5f;

    //Evita que la llave reaparezca si se vuelve a la escena
    void Start()
    {
        if (GameStateSingleton.Instance.HasKey(keyId))
            gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (GameStateSingleton.Instance.HasKey(keyId))
            return;

        GameStateSingleton.Instance.AddKey(keyId);

        //Desactiva el sprite de encima de la llave
        if (overlap != null)
            overlap.SetActive(false);

        // Oculta y muestra los mensajes por pantalla
        /* if (hideOtherMessage != null)
             hideOtherMessage.gameObject.SetActive(false);

         if (message != null)
             message.gameObject.SetActive(true);*/

        StartCoroutine(HideKeyAfterTime());

        MessageManager.Instance.ShowMessage("¿De dónde será esta llave?", 5f);
    }

    //Espera unos segundos para ocultar la llave
    IEnumerator HideKeyAfterTime()
    {
        yield return new WaitForSeconds(hideDelay);
        gameObject.SetActive(false);
    }
}
