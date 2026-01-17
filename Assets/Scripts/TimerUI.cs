using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] SceneLoader sceneLoader;


    private Color normalColor;

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

        HandleWarningTime(GameStateSingleton.Instance);

        if (GameStateSingleton.Instance.gameOver)
        {
            sceneLoader.GameOverScene();
        }
    }

    void HandleWarningTime(GameStateSingleton gs)
    {
        if (!gs.isWarningActive)
        {
            timerText.color = normalColor;
            timerText.alpha(1f);
            return;
        }

        // Parpadeo usando alpha
        float alpha = Mathf.PingPong(Time.unscaledTime / gs.blinkSpeed, 1f);
        timerText.color = new Color(gs.warningColor.r, gs.warningColor.g, gs.warningColor.b, alpha);
    }

}

public static class TMP_TextExtensions
{
    public static void alpha(this TMP_Text text, float a)
    {
        Color c = text.color;
        c.a = a;
        text.color = c;
    }
}