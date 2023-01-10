using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    private AudioSource buttonSound;

    private void Awake()
    {
        buttonSound = gameObject.GetComponent<AudioSource>();
    }

    public void Intro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Stage()
    {
        SceneManager.LoadScene("Stage");
    }

    public void Sound()
    {
        SceneManager.LoadScene("Sound");
    }

    public void ReStart()
    {
        SceneManager.LoadScene("EscapeRoom");
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

        SceneManager.LoadScene("EscapeRoom");
    }

    public void StageChose(int stageNumber)
    {
        if (Json.Instance.data.maxGameStage >= stageNumber)
        {
            Json.Instance.Read();
            Json.Instance.data.nowGameStage = stageNumber;
            Json.Instance.Save();

            SceneManager.LoadScene("EscapeRoom");
        }
    }

    public void TextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ButtonClickSound()
    {
        buttonSound.Play();
    }
}
