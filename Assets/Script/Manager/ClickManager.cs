using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FD.Dev;

public class ClickManager : MonoBehaviour
{
    private AudioSource buttonSound;

    private void Awake()
    {
        buttonSound = gameObject.GetComponent<AudioSource>();
    }

    public void Intro()
    {
        FAED.InvokeDelay(() => { SceneManager.LoadScene("Intro"); }, 0.2f);
    }

    public void Stage()
    {
        FAED.InvokeDelay(() => { SceneManager.LoadScene("Stage"); }, 0.2f);
    }

    public void Sound()
    {
        FAED.InvokeDelay(() => { SceneManager.LoadScene("Sound"); }, 0.2f);
    }

    public void ReStart()
    {
        FAED.InvokeDelay(() => { SceneManager.LoadScene("EscapeRoom"); }, 0.2f);
    }

    public void NextStage()
    {
        Json.Instance.Read();

        if (Json.Instance.data.maxGameStage == Json.Instance.data.nowGameStage)
        {
            Json.Instance.data.maxGameStage = Json.Instance.data.nowGameStage + 1;
        }
        Json.Instance.data.nowGameStage += 1;

        Json.Instance.Save();

        FAED.InvokeDelay(() => { SceneManager.LoadScene("EscapeRoom"); }, 0.2f);
    }

    public void StageChose(int stageNumber)
    {
        if (Json.Instance.data.maxGameStage >= stageNumber)
        {
            Json.Instance.Read();
            Json.Instance.data.nowGameStage = stageNumber;
            Json.Instance.Save();

            FAED.InvokeDelay(() => { SceneManager.LoadScene("EscapeRoom"); }, 0.2f);
        }
    }


    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void TextScene(string scene)
    {
        FAED.InvokeDelay(() => { SceneManager.LoadScene(scene); }, 0.2f);
    }

    public void ButtonClickSound()
    {
        buttonSound.Play();
    }

    public void GameBgmReplayer()
    {
        SoundManager.Instance.PlayGameBgm();
    }
}
