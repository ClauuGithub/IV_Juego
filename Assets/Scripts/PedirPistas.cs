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
        
        GameStateSingleton.CogerLlave += darPista;
        Mensaje.HacerCodigo += darPista;
        Debug.Log("a");
        Pista = GameObject.Find("TextoPista").GetComponent<TMP_Text>();
        Debug.Log("b");
        Pista.text = pistas[0];
        Debug.Log("c");
        f = 0;
        Debug.Log("d");


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); Debug.Log("DESTRUI"); }
    }

    void Update()
    {
      
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
}
