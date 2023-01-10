using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextEvent : MonoBehaviour
{
    [SerializeField] private Text gameOverText;
    [SerializeField] private GameObject buttonParent;

    void Start()
    {
        gameOverText.transform.DOScale(new Vector2(0.5f, 0.5f), 0.3f).SetEase(Ease.OutBounce)
        .OnComplete(() => {
            buttonParent.transform.DOMove(Vector2.zero, 1f).SetEase(Ease.OutQuad);
        });
    }
}
