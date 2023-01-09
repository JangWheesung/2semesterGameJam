using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private float speed;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public bool getKey { get; set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; }

        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 pos = new Vector2(x, y);
        rigidbody2D.velocity = speed * pos.normalized;

        if (x == 0 && y == 0) animator.SetBool("Run", false);
        else animator.SetBool("Run", true);

        if (Input.GetKey(KeyCode.A)) spriteRenderer.flipX = true;
        if (Input.GetKey(KeyCode.D)) spriteRenderer.flipX = false;
    }

    private void OpenDoor()
    {
        Json.Instance.Read();
        if (Json.Instance.data.maxGameStage == Json.Instance.data.nowGameStage)
        {
            Json.Instance.data.maxGameStage = Json.Instance.data.nowGameStage + 1;
        }
        Json.Instance.Save();

        DOTween.KillAll();

        SceneManager.LoadScene("Clear");
    }


    private void Die()
    {
        DOTween.KillAll();

        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (getKey == true && collision.transform.CompareTag("Door"))
        {
            OpenDoor();
        }
        if (collision.transform.CompareTag("Trap"))
        {
            Die();
        }
    }
}
