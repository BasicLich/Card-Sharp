using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool isFlipped;
    public Animator animator;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetString("SceneToLoad", SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Weapon.bulletAmount > 0)
        {
            if (!(DialogueManager.dialogueIsActive))
            {
                if (Time.timeScale != 0)
                {
                    if (isGrounded == true)
                    {
                        float move = Input.GetAxisRaw("Horizontal");
                        animator.SetFloat("Speed", Mathf.Abs(speed * move));
                    }
                    else
                    {
                        animator.SetFloat("Speed", 0);
                    }
                    isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
                    if (isGrounded == true && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
                    {
                        isJumping = true;
                        jumpTimeCounter = jumpTime;
                        rb.velocity = Vector2.up * jumpForce;
                    }
                    if (((Input.GetKey(KeyCode.UpArrow)) || Input.GetKey(KeyCode.W)) && isJumping == true)
                    {
                        if (jumpTimeCounter > 0)
                        {
                            rb.velocity = Vector2.up * jumpForce;
                            jumpTimeCounter -= Time.deltaTime;
                        }
                        else
                        {
                            isJumping = false;
                        }
                    }
                    if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
                    {
                        isJumping = false;
                    }
                }
                else
                {
                    rb.velocity = Vector2.up * 0;
                }
            }
            else
            {
                rb.velocity = new Vector3(0, -50);
            }
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    void FixedUpdate()
    {
        if (!(DialogueManager.dialogueIsActive))
        {
            float move = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(speed * move, rb.velocity.y);
            if (!(Input.GetButton("Fire1")) && Weapon.bulletAmount > 1)
            {
                if (move > 0 && isFlipped)
                {
                    Flip();
                }
                else if (move < 0 && !isFlipped)
                {
                    Flip();
                }
            }
        }
    }
    void Flip()
    {
        isFlipped = !isFlipped;
        transform.Rotate(0f, 180f, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillLine")
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            Weapon.bulletAmount -= 5;
        }
    }
}