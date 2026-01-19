using TMPro;
using UnityEngine;

public class PedirPistas : MonoBehaviour
{
    public static PedirPistas Instance;
    public string[] pistas = new string[10];

    public string ayuda;

    public TMP_Text Pista;

    int f = 0;
    void Awake()
    {
        
        GameStateSingleton.CogerLlave += darPista;
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
    }

    public void MostrarPista() 
    {
        Pista.text = ayuda;
    }
}
