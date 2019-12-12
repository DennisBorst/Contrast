using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private int playerID = 0;

    [Header("General stats")]
    [SerializeField] private int gameLifes;
    [SerializeField] private int amountOfJumps = 2;
    [SerializeField] private int jumpCount = 0;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float slideSpeed;

    //under the hood stats
    private float currentMovementSpeed;
    [SerializeField] private bool grounded;
    private bool isInAir = false;
    private float beginGravity;

    //GameObject stuff
    [Header("GameObject stuff")]
    private Rigidbody2D rb;

    //keyCodes
    [HideInInspector] public KeyCode baseAttackCode;
    [HideInInspector] public KeyCode specialAttackCode;
    private KeyCode jumpCode;
    private KeyCode startButton;

    //other
    public Vector2 input;

    //Hit related (probably not necessary)
    private PlayerMovement characterThatHitYou;
    public float damageTaken;
    [SerializeField] private bool knockbackHit;
    [SerializeField] private float knockbackHitTimer;
    [SerializeField] private float damageTimeMultiplayer;
    private float currentKnockbackHitTimer;
    [SerializeField] private float damageMultiplier;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        beginGravity = rb.gravityScale;
        ConfigureControlButtons();

        currentKnockbackHitTimer = knockbackHitTimer;
    }

    // Update is called once per frame
    private void Update()
    {
        Jumping();
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

    private void DamageDisplay()
    {
        //UIManager.Instance.DecreaseHeart(playerID, gameLifes, Mathf.RoundToInt(damageTaken));
    }

    private void Moving()
    {
        currentMovementSpeed = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        if (input.x > 0.2f || input.x < -0.2f || input.y > 0.2f || input.y < -0.2f)
        {
            rb.velocity = new Vector2(currentMovementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void Jumping()
    {
        
        if (Input.GetKeyDown(jumpCode) && grounded)
        {
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
        if(collision.gameObject.tag == "DeathZone" || collision.gameObject.tag == "Enemy")
        {
            Respawn();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Hitbox>())
        {
            Debug.Log("enemy hit here on this spot");
            if (collision.gameObject.GetComponent<Hitbox>().Character)
            {
                Debug.Log("enemy hit here");
                //if it doesnt come from the player itself
                if (collision.gameObject.GetComponent<Hitbox>().Character != this)
                {
                    //take damage
                    Debug.Log("enemy hit");
                }
            }
        }
    }

    private void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
