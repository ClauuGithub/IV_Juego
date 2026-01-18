using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//Singleton que crea un MessageManager global para no tener que duplicarlo en todas las escenas
//Uso general para mostrar mensajes que NO son diálogos
public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance;

    public TextMeshProUGUI messageText; //campo general para mensajes, será siempre el mismo
    public GameObject background;
    public float typeSpeed = 0.03f;

    private Coroutine typingRoutine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Detecta cambios de escena para no mostrar los mensajes durante el cambio
        }
        else Destroy(gameObject);
    }

    public void SetSlowSpeed(bool slow)
    {
        if (slow)
            typeSpeed = 0.01f;   //velocidad más lenta (más tiempo entre letra y letra)
        else
            typeSpeed = 0.03f;
    }

    public void ShowMessage(string text, float duration = 3f)
    {
        if (typingRoutine != null)
            StopCoroutine(typingRoutine);

        background.SetActive(true);

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
        background.SetActive(false);
    }

    


    //Detiene los mensajes cuando se cambia de escena para que no continúen en la siguiente
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
            typingRoutine = null;
        }
        messageText.text = "";
        background.SetActive(false);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
