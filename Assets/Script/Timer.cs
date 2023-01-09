using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    [SerializeField] private Vector2 timerMovePos;

    private Text text;
    float time;

    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
        time = 10;
    }

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(text.transform.DOScale(new Vector2(4, 4), 10))
            .Join(text.transform.DOMove(timerMovePos, 10))
            .Join(text.DOColor(Color.red, 10));
    }

    private void Update()
    {
        timerDecrease();
    }

    void timerDecrease()
    {
        time -= Time.deltaTime;
        text.text = time.ToString("F2");

        if (time <= 0) { DOTween.KillAll(); SceneManager.LoadScene("GameOver"); }
    }
}
