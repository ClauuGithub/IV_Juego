using UnityEngine;
using UnityEngine.SceneManagement;

public class CrownTouch : MonoBehaviour
{
    void OnMouseDown()
    {
        GameStateSingleton.Instance.RegisterFinishTime();
        SceneManager.LoadScene("CutSceneEnd");
        

    }
}
