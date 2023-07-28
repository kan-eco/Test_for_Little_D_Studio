using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 400;
    bool onGround = false;

    Rigidbody2D body;

    [SerializeField]
    GameObject ballPrefab;

    SpriteRenderer rend;
    GameObject ball;
    public float BallDistance = 5;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ball = GameObject.FindGameObjectWithTag("ball");


            if (Vector2.Distance(transform.position, ball.transform.position) >= BallDistance)
            {
                Destroy(ball);
                rend.color = Color.yellow;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && ball == null)
        {
            Instantiate(ballPrefab);
            ballPrefab.transform.position = transform.localPosition + new Vector3(2, 0.5f, 0);
            rend.color = Color.white;
        }


        //CallBall();
        Movement();
    }


    void Movement()

    {
        //но ей богу, через транслейт гибче
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector2.right * speed);
        }

        if (Input.GetKeyDown(KeyCode.W) && onGround == true)
        {
            body.AddForce(Vector2.up * jumpForce);
            onGround = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }

    void CallBall()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ball = GameObject.FindGameObjectWithTag("ball");


            if (Vector2.Distance(transform.position, ball.transform.position) >= BallDistance)
            {
                Destroy(ball);
                rend.color = Color.yellow;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && ball == null)
        {
            Instantiate(ballPrefab);
            ballPrefab.transform.position = transform.localPosition + new Vector3(2,0.5f,0);
            rend.color = Color.white;
        }
    }
}
