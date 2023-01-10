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

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");

        keySound = gameObject.GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        FAED.PlaySound("d");
    }

    void Update()
    {
        Collider2D playerRange = Physics2D.OverlapBox(transform.position, playerRangeBox, 0, playerLayer);

        if (playerRange != null)
        {
            Appear();
        }
    }

    void Appear()
    {
        Debug.Log("Find");

        Player.Instance.getKey = true;

        spriteRenderer.enabled = true;

        keySound.Play();

        transform.position = new Vector2(player.transform.position.x + playerGetPosition.x, player.transform.position.y + playerGetPosition.y);
        transform.parent = player.transform;
    }
}
