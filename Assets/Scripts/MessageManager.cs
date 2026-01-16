using UnityEngine;
using TMPro;
using System.Collections;

//Singleton que crea un MessageManager global para no tener que duplicarlo en todas las escenas
//Uso general para mostrar mensajes que NO son diálogos
public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance;

    public TextMeshProUGUI messageText; //indicar el mensaje en el editor
    public float typeSpeed = 0.03f;

    private Coroutine typingRoutine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void ShowMessage(string text, float duration = 3f)
    {
        if (typingRoutine != null)
            StopCoroutine(typingRoutine);

        typingRoutine = StartCoroutine(TypeAndHide(text, duration));
    }

    IEnumerator TypeAndHide(string text, float duration)
    {
        messageText.text = "";

        foreach (char c in text)
        {
            messageText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return new WaitForSeconds(duration);
        messageText.text = "";
    }
}
