using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 25f;
    public float runningSpeed = 1.5f;
    public LayerMask groundLayer;
    public Animator animator;
    public static PlayerController instance;

    private Rigidbody2D rigidBody;
    public Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        instance = this;
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            animator.SetBool("isGrounded", isGrounded());
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            }
        }
    }

    void Jump()
    {
        if (isGrounded())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    bool isGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
       
        } else
        {
            return false;
        }
    }

    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);
    }

    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        this.rigidBody.velocity = new Vector2(0.0f, 0.0f);
        this.transform.position = startingPosition;
    }
}
