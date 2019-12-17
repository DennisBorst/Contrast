using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float yIncrease;
    [SerializeField] private float playerY;
    private float currentY = 0;

    // Update is called once per frame
    private void Update()
    {
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.transform.position = new Vector3(this.transform.position.x, currentY, this.transform.position.z);

        if (playerTransform.transform.position.y > playerY)
        {
            currentY += yIncrease;
            this.transform.position = new Vector3(this.transform.position.x, playerY, this.transform.position.z);
            playerY += yIncrease;
        }
    }
}
