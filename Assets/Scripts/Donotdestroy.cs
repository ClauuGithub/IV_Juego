using UnityEngine;

public class Donotdestroy : MonoBehaviour
{
    public static Donotdestroy Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(gameObject); 
            Debug.Log("db");
             // Asi el objeto no se destruye entre escenas
        }
        else {
            Debug.Log("ab");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        }

    
}
