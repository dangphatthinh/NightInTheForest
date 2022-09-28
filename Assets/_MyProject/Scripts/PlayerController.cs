using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float jumpForce = 4.5f;

    private Rigidbody2D rigi;
    private Animator animator;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip jumpClip, pingClip, diedClip;

    private bool isAlive;
    private bool onGround;
    private bool didJump;

    public float flag = 0;
    
    public int score;

    private void Awake()
    {
        isAlive = true;
        rigi = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        MakeInstance();
        
    }
    private void Update()
    {
        PlayerMovement();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlayerMovement()
    {
        if (isAlive)
        {
            if (onGround&&didJump)
            {
                onGround = false;
                didJump = false;
                rigi.velocity = new Vector2(rigi.velocity.x, jumpForce);
                animator.SetTrigger("Jump");
                audioSource.PlayOneShot(jumpClip);
            }
        }      
    }
    public void JumpButton()
    {
        didJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Score")
        {
            score++;
            if(GameController.instance != null)
            {
                GameController.instance.SetScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;          
                audioSource.PlayOneShot(diedClip);
            }
            GameController.instance._ShowPanel(score);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
