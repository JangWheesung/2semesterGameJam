using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using FD.Dev;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider globalSlider;
    [SerializeField] private Slider touchSlider;

    void Start()
    {
        Json.Instance.Read();
        soundSlider.value = Json.Instance.data.sound;
        globalSlider.value = Json.Instance.data.globalLight;
        touchSlider.value = Json.Instance.data.touchLight;

        if (soundSlider.value == -20f) masterMixer.SetFloat("Base", -80);
        else masterMixer.SetFloat("Base", soundSlider.value);

        Json.Instance.data.globalLight = globalSlider.value;
        Json.Instance.data.touchLight = touchSlider.value;

        Json.Instance.Save();
    }

    public void AudioControl()
    {
        Json.Instance.Read();

        float sound = soundSlider.value;

        if (sound == -20f) masterMixer.SetFloat("Base", -80);
        else masterMixer.SetFloat("Base", sound);

        Json.Instance.data.sound = sound;

        Json.Instance.Save();
    }

    public void GlobalControl()
    {
        Json.Instance.Read();
        Json.Instance.data.globalLight = globalSlider.value;
        Json.Instance.Save();
    }

    public void TouchControl()
    {
        Json.Instance.Read();
        Json.Instance.data.touchLight = touchSlider.value;
        Json.Instance.Save();
    }
}
