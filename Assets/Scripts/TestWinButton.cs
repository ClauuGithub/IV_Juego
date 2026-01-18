using UnityEngine;

public class TestWinButton : MonoBehaviour
{
    public void SimulateWin()
    {
        Debug.Log("TEST WIN");
        GameStateSingleton.Instance.RegisterFinishTime();
    }
}

