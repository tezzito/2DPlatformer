using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //скорость движения
    [SerializeField] private int lives = 5; //количество жизней
    [SerializeField] private float jumpForce = 15f; //сила прыжка   
    public bool isGrounded = false;

    public bool game = true;
    public APITest api;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public Timer timer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();  
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (transform.position.y < -15) Die();
        if (Input.GetButton("Horizontal"))
            Run();
        else if (isGrounded) anim.SetInteger("state", 0);

        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
        if (isGrounded) anim.SetInteger("state", 1);

    }
     
    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.8f);
        foreach (Collider2D col in collider)
        {

            if (col.gameObject.tag == "Finish") Finish();
        }
        isGrounded = collider.Length > 1;
        if (!isGrounded) anim.SetInteger("state", 2);
    }

    public void Finish()
    {
        if (!game) return;
        game = false;
        timer.timerIsRunnig = false;
        api.SendResult(timer.passedTime);
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


