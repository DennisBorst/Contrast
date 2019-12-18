using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform contraWeight;

    [SerializeField] private float upSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float maxY;
    private float currentY;
    private float minY;

    [SerializeField] private bool isPressing = false;
    private bool reachedTheTop = false;

    private AudioSource source;

    // Start is called before the first frame update
    private void Start()
    {
        minY = this.transform.position.y;
    }

    private void Update()
    {
        currentY = this.transform.position.y;

        
        if (isPressing && currentY <= maxY)
        {
            reachedTheTop = true;

            if (!source.isPlaying)
            {
                source.Play();
            }

            Camera.main.transform.DOShakePosition(0.05f, 0.1f, 20, 90, false, true);
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y + (maxY - minY), this.transform.position.z), upSpeed);
            contraWeight.transform.position = Vector3.Lerp(contraWeight.transform.position, new Vector3(contraWeight.transform.position.x, contraWeight.transform.position.y + ((maxY - minY) * -1), contraWeight.transform.position.z), upSpeed);
        }

        if (isPressing)
        {
            return;
        }

        if (currentY > minY)
        {
            if (!source.isPlaying)
            {
                source.Play();
            }

            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - fallSpeed, this.transform.position.z);
            contraWeight.transform.position = new Vector3(contraWeight.transform.position.x, contraWeight.transform.position.y - (fallSpeed * -1), contraWeight.transform.position.z);
        }
    }


    private void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message

        Debug.Log("Hanging object");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isPressing = !isPressing;
            reachedTheTop = false;
        }
    }
}
