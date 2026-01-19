using UnityEngine;
using TMPro;
using System.Collections;

public class KeyNotFound : MonoBehaviour
{
    void OnMouseDown()
    {
        MessageManager.Instance.ShowMessage("Aquí no hay nada", 5f);
    }
}
