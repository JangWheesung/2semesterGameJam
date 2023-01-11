using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FD.Dev;

public class ClearManager : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject endingText;

    void Start()
    {
        Json.Instance.Read();
        if (Json.Instance.data.maxGameStage == 0) nextButton.SetActive(false); Json.Instance.data.maxGameStage = 1;
        if (Json.Instance.data.maxGameStage > 12) nextButton.SetActive(false); FAED.InvokeDelay(() => { endingText.transform.DOMoveY(0, 1f);}, 0.3f);
        Json.Instance.Save();
    }

    void Update()
    {
        
    }
}
