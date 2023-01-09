using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private float speed;

    private new Rigidbody2D rigidbody2D;
    public bool getKey { get; set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; }

        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
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
    }

    private void OpenDoor()
    {
        Json.Instance.Read();
        if (Json.Instance.data.maxGameStage == Json.Instance.data.nowGameStage)
        {
            Json.Instance.data.maxGameStage = Json.Instance.data.nowGameStage + 1;
        }
        Json.Instance.Save();

        SceneManager.LoadScene("Clear");
    }

    private void OnCollisionEnter2D(Collision2D door)
    {
        if (getKey == true && door.transform.CompareTag("Door"))
        {
            OpenDoor();
        }
    }
}