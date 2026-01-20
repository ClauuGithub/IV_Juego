using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class RankingUI : MonoBehaviour
{
    [SerializeField] TMP_Text[] rankingTexts; // Top1, Top2, Top3 

    void OnEnable()
    {
        UpdateUI();
    }

    void Update()
    {
        var gs = GameStateSingleton.Instance;
        if (gs == null) return;

        if (!gs.rankingDirty) return;

        RecalculateRanking(gs.bestTimes);
        UpdateUI();

        gs.rankingDirty = false;
    }

    void RecalculateRanking(List<float> times)
    {
        times.Sort((a, b) => b.CompareTo(a));

        if (times.Count > 3)
            times.RemoveRange(3, times.Count - 3);
    }

    void UpdateUI()
    {
        var times = GameStateSingleton.Instance.bestTimes;

        for (int i = 0; i < rankingTexts.Length; i++)
        {
            if (i < times.Count)
            {
                int min = (int)(times[i] / 60f);
                int sec = (int)(times[i] % 60f);
                rankingTexts[i].text = $"{min:00}:{sec:00}";
            }
            else
            {
                rankingTexts[i].text = "--:--";
            }
        }
    }
}
