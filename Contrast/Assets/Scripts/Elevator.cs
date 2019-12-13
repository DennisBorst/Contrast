using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject elevator;

    [SerializeField] private float upSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float maxY;
    private float currentY;
    private float minY;

    [SerializeField] private bool isPressing = false;
    private bool reachedTheTop = false;

    // Start is called before the first frame update
    private void Start()
    {
        minY = elevator.transform.position.y;
    }

    private void Update()
    {
        currentY = elevator.transform.position.y;

        if (isPressing && currentY <= maxY)
        {
            reachedTheTop = true;
            elevator.transform.position = Vector3.Lerp(elevator.transform.position, new Vector3(elevator.transform.position.x, elevator.transform.position.y + (maxY - minY), elevator.transform.position.z), upSpeed);
        }

        if (isPressing)
        {
            return;
        }

        if (currentY > minY)
        {
            elevator.transform.position = new Vector3(elevator.transform.position.x, elevator.transform.position.y - fallSpeed, elevator.transform.position.z);
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
