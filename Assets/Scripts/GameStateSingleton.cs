using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.Rendering;

//Singleton que guarda el estado entre escenas, en este caso, detecta cuando se ha recogido una llave, para poder usarla en otra escena
public class GameStateSingleton : MonoBehaviour
{
    // Guarda una unica instancia global para todas las escenas
    public static GameStateSingleton Instance { get; private set; }

    public static event Action<int> CogerLlave;

    //Almacena las llaves recogidas
    private HashSet<string> keys = new HashSet<string>();

    // TIMER
    [Header("Timer")]
    public float maxTime = 120f;
    public float currentTime;
    public bool isPaused;
    public bool gameOver;

    [Header("Aviso Timer")]
    public float warningTime = 10f;
    public bool isWarningActive; // si el timer debería parpadear
    public float blinkTimer;
    public Color warningColor;
    public float blinkSpeed = 0.5f; // velocidad en segundos

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Asi el objeto no se destruye entre escenas
            ResetTimer();
        }
        else Destroy(gameObject);           // Destruye si el objeto está duplicado en otra escena
    }

    private void Update()
    {
        if (isPaused || gameOver) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            gameOver = true;
            isWarningActive = false;
        }

        // Parpadeo de aviso
        if (currentTime <= warningTime)
        {
            isWarningActive = true;
        }
        else
        {
            isWarningActive = false;
            blinkTimer = 0f;
        }
    }

    public void ResetTimer()
    {
        currentTime = maxTime;
        isPaused = false;
        gameOver = false;
        isWarningActive = false;
        blinkTimer = 0f;
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
