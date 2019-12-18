using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        Camera.main.transform.DOShakePosition(.4f, .5f, 20, 90, false, true);
        AudioManager.Instance.PlaySound(AudioFragments.BoulderCrashing, AudioPlayers.Interactable);

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
