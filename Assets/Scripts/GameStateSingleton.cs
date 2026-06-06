using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//Singleton que guarda el estado entre escenas
//Guarda la llave, el timer, las gemas y el ranking
public class GameStateSingleton : MonoBehaviour
{
    // Guarda una unica instancia global para todas las escenas
    public static GameStateSingleton Instance { get; private set; }

    public static event Action<int> CogerLlave;

    // STATE AÑADIDO
    public enum GameState
    {
        MainMenu,
        SearchingKey,
        KeyFound,
        CarUnlocked,
        BalconyUnlocked,
        GodsPuzzleSolved,
        GameCompleted
    }

    //Almacena las llaves recogidas
    private HashSet<string> keys = new HashSet<string>();

    //Estado coche cerrado/abierto
    /*public bool carUnlocked = false;
    //Estado codigo resuelto
    public bool codeSolved = false;
    */

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

    //Aplicación PATRÓN STATE estado actual
    public GameState currentState = GameState.SearchingKey;

    [Header("Puzzle Estatuas")]
    public string carriedStatue = "";
    public HashSet<string> collectedStatues = new HashSet<string>();
    public HashSet<string> placedStatues = new HashSet<string>();

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
        Debug.Log(currentState);  // Debug para mostrar el estado de la partida en todo momento

        // Si estamos pausados, muertos o en el MENÚ PRINCIPAL, no hacemos nada
        if (isPaused || gameOver || currentState == GameState.MainMenu) return;

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
        Time.timeScale = 1f;
    }

    public void AddKey(string keyId)
    {
        keys.Add(keyId);
        CogerLlave?.Invoke(1);
    }

    /*public void AddKey(string keyId)
    {
        keys.Add(keyId);

        if (keyId == "CarKey")
        {
            currentState = GameState.KeyFound;
        }

        CogerLlave?.Invoke(1);
    }*/

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

    //Resetear el estado del juego al volver al menu (en el SceneLoader)
    public void ResetGameState()
    {
        keys.Clear();

        currentState = GameState.MainMenu;
        //carUnlocked = false;
        //codeSolved = false;

        ResetTimer();

        ResetGems();

        PedirPistas.Instance.ResetPistas();

        isPaused = false;
        gameOver = false;
        isWarningActive = false;
        blinkTimer = 0f;

        rankingDirty = false;
    }

    /*public void StartGame()
    {

        Time.timeScale = 1f; 
        // Aseguramos que todo está limpio
        keys.Clear();
        ResetTimer();
        ResetGems();

        // AHORA SÍ iniciamos la partida
        currentState = GameState.SearchingKey;
    }*/

}

