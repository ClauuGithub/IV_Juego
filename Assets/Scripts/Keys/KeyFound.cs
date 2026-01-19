using UnityEngine;
using TMPro;
using System.Collections;

public class KeyFound : MonoBehaviour
{
    public GameObject overlap;                  // sprite que tapa la llave

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
