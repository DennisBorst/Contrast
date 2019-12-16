using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer blueOutline;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (blueOutline != null)
        {
            blueOutline.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (blueOutline != null)
        {
            blueOutline.enabled = true;
        }
        if (collision.gameObject.layer == 12)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;

            if(blueOutline != null)
            {
                blueOutline.enabled = false;
            }
        }
    }
}
