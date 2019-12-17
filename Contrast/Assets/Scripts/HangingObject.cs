using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HangingObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbBox;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject redRope;

    // Start is called before the first frame update
    void Start()
    {
        rbBox.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            rbBox.isKinematic = true;
        }
    }

    private void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Hanging object");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rbBox.isKinematic = false;
            Camera.main.transform.DOShakePosition(.3f, .1f, 20, 90, false, true);
            Destroy(redRope.gameObject);
        }
    }
}
