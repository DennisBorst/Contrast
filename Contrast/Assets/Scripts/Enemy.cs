using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private float rayGroundDistance = 1f;

    private bool movingRight = true;

    public Transform groundDetection;
    public GameObject player;
    private Rigidbody2D rb;

    public LayerMask groundLayer;
    public float collisionRadius = 0.25f;
    public Vector2 rightOffset, leftOffset;

    public bool onWall;

    private bool switchedSide;
    private float switchTimer;
    private float currentSwitchTimer;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentSwitchTimer = switchTimer;
    }

    // Update is called once per frame
    private void Update()
    {
        Patrol();
        CheckPlayerDistance();
    }

    private void Patrol()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (!source.isPlaying)
        {
            source.Play();
        }

        if (switchedSide)
        {
            currentSwitchTimer = Timer(currentSwitchTimer);
            if (currentSwitchTimer <= 0)
            {
                switchedSide = false;
                currentSwitchTimer = switchTimer;
            }

            return;
        }

        SwitchEnemySide();
    }

    private void SwitchEnemySide()
    {
        switchedSide = true;

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayGroundDistance, groundLayer);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer)
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        if (groundInfo.collider == false || onWall)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void CheckPlayerDistance()
    {
        float distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);
        float distanceY = Mathf.Abs(player.transform.position.y - transform.position.y);
        if (distanceX < 6.0 && distanceY < 1.5)
        {
            bool playerIsLeft = player.transform.position.x - transform.position.x > 0;
            if (!playerIsLeft)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }
}
