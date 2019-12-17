using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int playerID = 0;

    [SerializeField] private bool startAnimation = false;

    [Header("General stats")]
    [SerializeField] private int gameLifes;
    [SerializeField] private int amountOfJumps = 2;
    [SerializeField] private int jumpCount = 0;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float slideSpeed;

    //under the hood stats
    [SerializeField] private bool grounded;
    private bool isInAir = false;
    private float currentMovementSpeed;
    private float beginGravity;

    //GameObject stuff
    private Animator anim;
    private Rigidbody2D rb;

    //keyCodes
    [HideInInspector] public KeyCode baseAttackCode;
    [HideInInspector] public KeyCode specialAttackCode;
    private KeyCode jumpCode;
    private KeyCode startButton;

    //other
    public Vector2 input;

    //Particles
    [SerializeField] private ParticleSystem jumpParticle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        beginGravity = rb.gravityScale;
        ConfigureControlButtons();
        anim = GetComponent<Animator>();

        Vector3 characterScale = transform.localScale;
        if (startAnimation)
        {
            characterScale.x = -1;
        }
        transform.localScale = characterScale;
    }

    // Update is called once per frame
    private void Update()
    {
        Jumping();

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("isDying");
            movementSpeed = 0;
            currentMovementSpeed = 0;
            this.enabled = false;
        }
    }

    void FixedUpdate()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Jumping();
        Moving();
        FlipCharacter();
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }

    private void Moving()
    {
        currentMovementSpeed = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        if (input.x > 0.2f || input.x < -0.2f || input.y > 0.2f || input.y < -0.2f)
        {
            anim.SetBool("isRunning", true);
            rb.velocity = new Vector2(currentMovementSpeed, rb.velocity.y);

            AudioManager.Instance.PlaySound(AudioFragments.WalkPlayer, AudioPlayers.Player);
        }
        else
        {
            anim.SetBool("isRunning", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void Jumping()
    {
        
        if (Input.GetKeyDown(jumpCode) && grounded)
        {
            AudioManager.Instance.PlaySound(AudioFragments.Jump, AudioPlayers.Player);

            Debug.Log("Jumping");
            isInAir = true;
            jumpCount++;
            //rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            Vector2 dir = Vector2.up;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += dir * jumpPower;

            if (jumpCount >= amountOfJumps)
            {
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            movementSpeed = 0;
            currentMovementSpeed = 0;
            this.enabled = false;

            AudioManager.Instance.PlaySound(AudioFragments.DeathPlayer, AudioPlayers.Player);
            anim.SetTrigger("isDying");
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            movementSpeed = 0;
            currentMovementSpeed = 0;
            this.enabled = false;

            AudioManager.Instance.PlaySound(AudioFragments.Hit, AudioPlayers.Player);
            anim.SetTrigger("isDying");
        }

        if (collision.gameObject.tag == "Ground")
        {
            jumpParticle.Play();
            AudioManager.Instance.PlaySound(AudioFragments.TouchDown, AudioPlayers.Player);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            isInAir = false;
            jumpCount = 0;
        }
        else
        {
            isInAir = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isInAir = true;
            jumpCount++;
        }
    }

    public void Respawn()
    {
        GameManager.Instance.Reload();
        //UIManager.Instance.DecreaseHeart(playerID, gameLifes, Mathf.RoundToInt(damageTaken));
    }

    private void FlipCharacter()
    {
        Vector3 characterScale = transform.localScale;

        if(currentMovementSpeed < -0.1f)
        {
            characterScale.x = -1;
        }
        else if (currentMovementSpeed > 0.1f)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }

    public void ConfigureControlButtons()
    {
        //controller identification for the buttons
        switch (playerID)
        {
            case 1:
                break;
            default:
                baseAttackCode = KeyCode.C;
                jumpCode = KeyCode.Space;
                specialAttackCode = KeyCode.X;
                startButton = KeyCode.Escape;
                break;
        }
    }
}
