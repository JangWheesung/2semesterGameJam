using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorlalManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI turorlalText;

    void Awake()
    {
        SoundManager.Instance.StopGameBgm();
    }

    private void Start()
    {
        Json.Instance.Read();
        Json.Instance.data.nowGameStage = 0;
        Json.Instance.Save();
    }

    void Update()
    {
        if (Player.Instance.getKey == true) { turorlalText.text = "Escape Now!"; }
    }
}
