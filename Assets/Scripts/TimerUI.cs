using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] SceneLoader sceneLoader;

    // Parpadeos de aviso de poco tiempo restante
    [SerializeField] float warningTime = 10f;
    [SerializeField] float blinkSpeed = 0.5f;
    [SerializeField] Color warningColor = Color.red;

    private Color normalColor;
    private float blinkTimer;

    void Start()
    {
        normalColor = timerText.color;
    }
    void Update()
    {
        if (GameStateSingleton.Instance == null) return;

        float time = GameStateSingleton.Instance.currentTime;

        int min = (int)(time / 60f);
        int sec = (int)(time % 60f);

        timerText.text = $"{min:00}:{sec:00}";

        HandleWarningTime(time);

        if (GameStateSingleton.Instance.gameOver)
        {
            sceneLoader.GameOverScene();
        }
    }

    void HandleWarningTime(float time)
    {
        if (time > warningTime)
        {
            timerText.color = normalColor;
            return;
        }

        blinkTimer += Time.unscaledDeltaTime; // aunque el juego esté pausado se sigue mostrando el parpadeo

        if (blinkTimer >= blinkSpeed)
        {
            blinkTimer = 0f;
            timerText.enabled = !timerText.enabled;

        }

        timerText.color = warningColor;
    }
}
