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

    void Update()
    {
        if (Player.Instance.getKey == true) { turorlalText.text = "Escape Now!"; }
    }
}
