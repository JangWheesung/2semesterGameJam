using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    [SerializeField] private Vector2 timerMovePos;

    private TextMeshProUGUI text;
    float time;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        time = 10;
    }

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(text.transform.DOScale(new Vector2(4, 4), 10))
            .Join(text.transform.DOMove(timerMovePos, 10));
    }

    private void Update()
    {
        timerDecrease();
    }

    void timerDecrease()
    {
        time -= Time.deltaTime;
        text.text = time.ToString("F2");

        if (time <= 0) { SceneManager.LoadScene("GameOver"); }
    }
}
