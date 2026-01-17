using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] private float MaxTime = 120f;
    [SerializeField] SceneLoader sceneLoader;

    private float timerTime;
    private int min, sec;
    private bool gameOverLaunched;

    void Start()
    {
        timerTime = MaxTime;
        gameOverLaunched = false;
    }
    void Update()
    {
        if (gameOverLaunched) return;
        
        timerTime -= Time.deltaTime;

        if (timerTime <= 0)
        {
            timerTime = 0;
            LaunchGameOver();
        }

        min = (int)(timerTime / 60f);
        sec = (int)(timerTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);

    }

    void LaunchGameOver()
    {
        gameOverLaunched = true;
        sceneLoader.GameOverScene();
    }
}
