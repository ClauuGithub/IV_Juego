using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;

//Singleton que guarda el estado entre escenas, en este caso, detecta cuando se ha recogido una llave, para poder usarla en otra escena
public class GameStateSingleton : MonoBehaviour
{
    // Guarda una unica instancia global para todas las escenas
    public static GameStateSingleton Instance { get; private set; }

    public static event Action<int> CogerLlave;

    //Almacena las llaves recogidas
    private HashSet<string> keys = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Asi el objeto no se destruye entre escenas
        }
        else Destroy(gameObject);           // Destruye si el objeto está duplicado en otra escena
    }

    public void AddKey(string keyId)
    {
        keys.Add(keyId);
        CogerLlave?.Invoke(1);
    }

    public bool HasKey(string keyId)
    {
        return keys.Contains(keyId);
    }
}
