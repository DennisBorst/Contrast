using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Clickable : MonoBehaviour
{
    [SerializeField] private bool interactable = true;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    private void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        Debug.Log("Bridge is ready");
        if (Input.GetKeyDown(KeyCode.Mouse0) && interactable)
        {
            interactable = false;
            anim.enabled = true;
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void CameraShake()
    {
        Camera.main.transform.DOShakePosition(.4f, .5f, 20, 90, false, true);
    }
}
