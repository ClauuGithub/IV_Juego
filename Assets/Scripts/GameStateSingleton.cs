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

    // PATRÓN STATE: Guarda el estado  del juego
    private IState currentStateObject;

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

    // Gemas
    [Header("Contador Gemas")]
    public int totalGems;

    [Header("Ranking")]
    public List<float> bestTimes = new List<float>();


    // El progreso inicia en SearchingKey
    public GameState currentState = GameState.SearchingKey;

    [Header("Puzzle Estatuas")]
    public string carriedStatue = "";
    public HashSet<string> collectedStatues = new HashSet<string>();
    public HashSet<string> placedStatues = new HashSet<string>();

    // DENTRO DE GAMESTATESINGLETON.CS (Añades esta línea arriba con tus variables)
    [HideInInspector] public string lastGameScene;

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

    // PATRÓN STATE
    public void SetState(IState newState)
    {
        if (currentStateObject != null) currentStateObject.Exit(); // Avisa al estado anterior que se apague
        currentStateObject = newState;
        if (currentStateObject != null) currentStateObject.Enter(); // Activa las condiciones del nuevo estado
    }

    void Start()
    {
        // SEGURO DE VIDA: Si la escena actual es la de juego y el estado es null (porque estás testeando),
        // o si venimos del menú pero queremos forzar el inicio del cronómetro:
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" && currentStateObject == null)
        {
            SetState(new PlayingState(this));
        }
    }

    // La lógica de actualización ahora es manejada por el patrón State
    private void Update()
    {
        // Mantenemos tu Debug.Log para que veas la progresión del puzle en la consola
        Debug.Log("Puzle actual: " + currentState + " | Estado mecánico: " + currentStateObject?.GetType().Name);

        // DELEGACIÓN POLIMÓRFICA PURA
        // Le decimos al estado actual: "Haz lo que te corresponda en este frame".
        // Si es PlayingState, restará tiempo. Si es PauseState o GameOverState, no hará nada.
        currentStateObject?.Update();
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

    public void AddGems(int amount)
    {
        totalGems += amount;
    }

    public void ResetGems()
    {
        totalGems = 0;
    }

    //RANKING
    public void RegisterFinishTime()
    {
        float newTime = maxTime - currentTime;

        bestTimes.Add(newTime);

        bestTimes.Sort((a, b) => a.CompareTo(b));

        if (bestTimes.Count > 3)
            bestTimes.RemoveRange(3, bestTimes.Count - 3);

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

        currentStateObject = null;

        ResetTimer();

        ResetGems();

        PedirPistas.Instance.ResetPistas();

        isPaused = false;
        gameOver = false;
        isWarningActive = false;
        blinkTimer = 0f;
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

