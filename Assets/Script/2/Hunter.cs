using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public static Hunter Instance;

    [SerializeField] private float speed;
    public bool isMove { get; set; }

    private new Rigidbody2D rigidbody2D;

    void Awake()
    {
        if (Instance == null) { Instance = this; }

        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Hunt();
    }
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMove = true;
            rigidbody2D.velocity = Vector2.right.normalized * speed * Time.deltaTime;
        }
        else
        {
            isMove = false;
        }
    }

    private void Hunt()
    {

    }
}
