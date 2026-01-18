using UnityEngine;
using UnityEngine.UI;

public class SlowToggleHandler : MonoBehaviour
{
    public Toggle slowToggle;

    void Start()
    {
        if (slowToggle != null)
        {
            slowToggle.onValueChanged.AddListener(OnToggleChanged);
        }
    }

    void OnToggleChanged(bool isOn)
    {
        // Llama al singleton de MessageManager
        if (MessageManager.Instance != null)
        {
            if (isOn)
            {
                MessageManager.Instance.SetSlowSpeed(true);
            }
            else
            {
                MessageManager.Instance.SetSlowSpeed(false);
            }
        }
    }
}
