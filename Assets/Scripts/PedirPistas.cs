using TMPro;
using UnityEngine;

public class PedirPistas : MonoBehaviour
{
    public static PedirPistas Instance;
    public string[] pistas = new string[10];

    public string ayuda;

    public bool changed = false;

    public TMP_Text Pista;

    int f = 0;
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // IMPORTANTE: Solo nos suscribimos una vez, en la instancia real que sobrevive
            GameStateSingleton.CogerLlave += darPista;
            Mensaje.HacerCodigo += darPista;

            InitTexto();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        PedirPistas.Instance?.InitTexto();
    }

    public void InitTexto()
    {
        GameObject textoObj = GameObject.Find("TextoPista");
        if (textoObj != null)
        {
            Pista = textoObj.GetComponent<TMP_Text>();
            Pista.text = string.IsNullOrEmpty(ayuda) ? pistas[0] : ayuda;
        }
    }
    public void darPista(int a) 
    { 
        ayuda = pistas[a];
        changed = true;
    }

    public void MostrarPista() 
    {
        if (changed == false)
        {
            MessageManager.Instance.ShowMessage(Pista.text, 5f);
            Pista.text = ayuda;
        }
        else {
            Pista.text = ayuda;
            MessageManager.Instance.ShowMessage(Pista.text, 5f);
        }
    }
    public void ResetPistas()
    {
        ayuda = pistas[0]; // Volvemos a la primera pista del juego
        changed = false;

        // Volvemos a buscar el componente de texto por si acaso cambiamos de escena
        InitTexto();
    }

    // OBLIGATORIO: Limpiar eventos al destruir
    private void OnDestroy()
    {
        if (Instance == this)
        {
            GameStateSingleton.CogerLlave -= darPista;
            Mensaje.HacerCodigo -= darPista;
        }
    }
}
