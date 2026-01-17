using UnityEngine;

public class GemsCounter : MonoBehaviour
{
    public static GemsCounter Instance;
    public int totalGems;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddGem(int value)
    {
        totalGems += value;
        Debug.Log("Gemas encontradas: " + totalGems);
    }
}

