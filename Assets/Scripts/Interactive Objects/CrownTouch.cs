using UnityEngine;
using UnityEngine.SceneManagement;

public class CrownTouch : MonoBehaviour
{
    void OnMouseDown()
    {
        GameStateSingleton.Instance.RegisterFinishTime();
        GameStateSingleton.Instance.SetState(new CutSceneState(GameStateSingleton.Instance));
        SceneManager.LoadScene("CutSceneEnd");
        

    }
}
