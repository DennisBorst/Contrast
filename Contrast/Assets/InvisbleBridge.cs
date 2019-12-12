using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisbleBridge : MonoBehaviour
{
    [SerializeField] private bool boxColliderOn = false;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        if (GetComponentInChildren<SpriteRenderer>())
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        Debug.Log("Bridge is ready");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SwitchBool();
        }
    }

    private void SwitchBool()
    {
        boxColliderOn = !boxColliderOn;

        if (boxColliderOn)
        {
            boxCollider.isTrigger = false;
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
            boxCollider.isTrigger = true;
        }
    }
}
