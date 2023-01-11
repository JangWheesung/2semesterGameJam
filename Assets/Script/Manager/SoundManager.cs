using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using FD.Dev;
using DG.Tweening.Core;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource gameBgm;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        gameBgm = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGameBgm()
    {
        gameBgm.Play();
    }

    public void StopGameBgm()
    {
        gameBgm.Stop();
    }
}
