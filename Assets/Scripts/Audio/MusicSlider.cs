using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public AudioMixer mixer;
    //public Slider slider;

    public void SliderControl (float slider)
    {
        mixer.SetFloat("GlobalVolume", Mathf.Log10(slider) * 20);
    }
    /*void Start()
    {
        float value;
        mixer.GetFloat("GlobalVolume", out value);
        slider.value = value;
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("GlobalVolume", volume);
    }*/
}
