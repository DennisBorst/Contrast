using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private bool interactable = true;
    [SerializeField] private bool enemy = true;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        Debug.Log("Bridge is ready");
        if (Input.GetKeyDown(KeyCode.Mouse0) && interactable)
        {
            if (enemy)
            {
                interactable = false;
                anim.enabled = true;
            }
            else
            {
                Destroy();
            }
        }
    }

    public void Destroy()
    {
        AudioManager.Instance.PlaySound(AudioFragments.DeathEnemy, AudioPlayers.Enemy);
        Destroy(this.gameObject);
    }
}
