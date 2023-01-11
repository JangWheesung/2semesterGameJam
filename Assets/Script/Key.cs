using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class Key : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Vector2 playerRangeBox;
    [SerializeField] private Vector2 playerGetPosition;
    [SerializeField] private LayerMask playerLayer;

    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private AudioSource keySound;

    private bool keyppear;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");

        keySound = gameObject.GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        keyppear = false;
    }

    void Update()
    {
        Collider2D playerRange = Physics2D.OverlapBox(transform.position, playerRangeBox, 0, playerLayer);

        if (playerRange != null)
        {
            Appear();
        }

        Range();
    }

    void Appear()
    {
        Player.Instance.getKey = true;

        KeySound();

        transform.position = new Vector2(player.transform.position.x + playerGetPosition.x, player.transform.position.y + playerGetPosition.y);
        transform.parent = player.transform;
    }

    private void Range()
    {
        Collider2D range = Physics2D.OverlapCircle(transform.position, 1.5f, playerLayer);

        if (range != null)
        {
            keyppear = true;

            spriteRenderer.enabled = true;
        }
        else
        {
            keyppear = false;

            spriteRenderer.enabled = false;
        }
    }

    private void KeySound()
    {
        if(keyppear == false) keySound.Play();
    }
}
