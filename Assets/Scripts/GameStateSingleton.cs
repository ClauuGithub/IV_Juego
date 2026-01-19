using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.Rendering;

//Singleton que guarda el estado entre escenas
//Guarda la llave, el timer, las gemas y el ranking
public class GameStateSingleton : MonoBehaviour
{
    // Guarda una unica instancia global para todas las escenas
    public static GameStateSingleton Instance { get; private set; }

    public static event Action<int> CogerLlave;

    //Almacena las llaves recogidas
    private HashSet<string> keys = new HashSet<string>();

    //Estado coche cerrado/abierto
    public bool carUnlocked = false;
    //Estado codigo resuelto
    public bool codeSolved = false;

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

    //Aplicación PATRÓN DIRTY FLAG
    [Header("Ranking")]
    public List<float> bestTimes = new List<float>();
    public bool rankingDirty;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Asi el objeto no se destruye entre escenas
            ResetTimer();
            ResetGems();
            LoadBestTimes();
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

    //Gemas
    [Header("Contador Gemas")]
    public int totalGems;

    public void AddGems(int amount)
    {
        totalGems += amount;
    }

    public void ResetGems()
    {
        totalGems = 0;
    }

    //RANKING DIRTY FLAG
    public void RegisterFinishTime()
    {
        float newTime = currentTime;

        if (bestTimes.Count < 3)
        {
            bestTimes.Add(newTime);
            rankingDirty = true;
            SaveBestTimes();
            return;
        }

        bestTimes.Sort((a, b) => b.CompareTo(a));

        if (newTime <= bestTimes[bestTimes.Count - 1])
            return;

        bestTimes.Add(newTime);
        rankingDirty = true;
        SaveBestTimes();
    }

    public void SaveBestTimes()
    {
        for (int i = 0; i < bestTimes.Count; i++)
        {
            PlayerPrefs.SetFloat($"BestTime{i}", bestTimes[i]);
        }
        PlayerPrefs.Save(); // asegura que se escriba en disco
    }

    private void LoadBestTimes()
    {
        bestTimes.Clear();
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.HasKey($"BestTime{i}"))
            {
                bestTimes.Add(PlayerPrefs.GetFloat($"BestTime{i}"));
            }
        }
    }

    public void ResetGameState()
    {
        // --- Progreso ---
        keys.Clear();
        carUnlocked = false;
        codeSolved = false;

        // --- Timer ---
        ResetTimer();

        // --- Gemas ---
        ResetGems();

        // --- Estados temporales ---
        isPaused = false;
        gameOver = false;
        isWarningActive = false;
        blinkTimer = 0f;

        // --- Eventos / flags ---
        rankingDirty = false;
    }

}

