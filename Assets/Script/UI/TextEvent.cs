using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextEvent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject buttonParent;

    void Start()
    {
        gameOverText.transform.DOScale(new Vector2(1, 1), 0.3f).SetEase(Ease.OutBounce)
        .OnComplete(() => {
            buttonParent.transform.DOMove(Vector2.zero, 1f).SetEase(Ease.OutQuad);
        });
    }
}
