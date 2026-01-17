using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] SceneLoader sceneLoader;

    void Update()
    {
        if (GameStateSingleton.Instance == null) return;

        float time = GameStateSingleton.Instance.currentTime;

        int min = (int)(time / 60f);
        int sec = (int)(time % 60f);

        timerText.text = $"{min:00}:{sec:00}";

        if (GameStateSingleton.Instance.gameOver)
        {
            sceneLoader.GameOverScene();
        }
    }
}
