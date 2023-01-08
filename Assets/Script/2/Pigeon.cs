using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    private enum Stats = {}

    [SerializeField] private Vector2 playerRangeBox;
    [SerializeField] private LayerMask playerLayer;

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
