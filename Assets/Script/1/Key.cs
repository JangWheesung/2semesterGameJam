using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Vector2 playerRangeBox;
    [SerializeField] private Vector2 playerGetPosition;
    [SerializeField] private LayerMask playerLayer;

    private GameObject player;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        //스테이지에 따라 지정된 위치로 이동
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

        transform.position = new Vector2(player.transform.position.x + playerGetPosition.x, player.transform.position.y + playerGetPosition.y);
        transform.parent = player.transform;
    }
}
