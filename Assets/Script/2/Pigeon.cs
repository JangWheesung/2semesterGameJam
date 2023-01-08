using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pigeon : MonoBehaviour
{
    private enum Stats { Eat, Boundary, Run };
    Stats stats = Stats.Eat;

    [SerializeField] private Vector2 playerRangeBox;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Slider slider;

    void Awake()
    {
        
    }

    void Update()
    {
        Fsm();
    }

    private void Fsm()
    {
        Collider2D playerRange = Physics2D.OverlapBox(transform.position, playerRangeBox, 0, playerLayer);
        if (playerRange == false)
        {
            Normally();
        }
        else
        {
            Climax();
        }
    }

    void Normally()
    {
        
    }

    void Climax()
    {

    }

    void Pawn()
    {
        
    }

    void Stat()
    {

    }
}
