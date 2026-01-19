using UnityEngine;

public class Donotdestroy : MonoBehaviour
{
    public static Donotdestroy Instance;
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
