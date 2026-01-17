using UnityEngine;
using TMPro;

public class GemsCounter : MonoBehaviour
{
    public TMP_Text counterText;

    void Update()
    {
        if (GameStateSingleton.Instance != null)
        {
            counterText.text = "Gemas: " + GameStateSingleton.Instance.totalGems;
        }
    }
}
