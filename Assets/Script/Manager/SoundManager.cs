using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private Slider slider;
    void Start()
    {
        Json.Instance.Read();
        slider.value = Json.Instance.data.sound;

        if (slider.value == -20f) masterMixer.SetFloat("Base", -80);
        else masterMixer.SetFloat("Base", slider.value);

        Json.Instance.Save();
    }

    public void AudioControl()
    {
        Json.Instance.Read();

        float sound = slider.value;

        if (sound == -20f) masterMixer.SetFloat("Base", -80);
        else masterMixer.SetFloat("Base", sound);

        Json.Instance.data.sound = sound;

        Json.Instance.Save();
    }
}
