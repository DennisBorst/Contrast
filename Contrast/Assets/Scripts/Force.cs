using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    [SerializeField] private Vector2 addForce;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Force object");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (rb.isKinematic == false)
            {
                rb.AddForce(addForce);  
            }
            //rb.velocity = new Vector2(this.transform.position.x + addForce.x, this.transform.position.y + addForce.y);
        }

    }
}
