using UnityEngine;
using TMPro;

public class GemsCounter : MonoBehaviour
{
    public static GemsCounter Instance;
    public int totalGems=0;
    public TMP_Text counterText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        UpdateUI();
    }
    public void AddGem(int value)
    {
        totalGems += value;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = "Gemas: " + totalGems;
        }
    }
}

