using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FD.Dev;

public class ClearManager : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;
    [SerializeField] private RectTransform menuButton;
    [SerializeField] private GameObject endingText;

    void Start()
    {
        Json.Instance.Read();
        if (Json.Instance.data.maxGameStage == 0)
        {
            nextButton.SetActive(false);
            menuButton.position = new Vector3(0, menuButton.position.y, 0);
            menuButton.position += new Vector3(0, 0, 648);
            Json.Instance.data.maxGameStage = 1;
        }
        if (Json.Instance.data.maxGameStage > 12)
        {
            nextButton.SetActive(false);
            menuButton.position = new Vector3(0, menuButton.position.y, 0);
            menuButton.position += new Vector3(0, 0, 648);
            FAED.InvokeDelay(() => { endingText.transform.DOMoveY(0, 1f); }, 0.3f);
        }
        Json.Instance.Save();
    }
}
