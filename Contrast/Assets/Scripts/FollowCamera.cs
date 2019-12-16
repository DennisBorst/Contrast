using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float yIncrease;
    [SerializeField] private float playerY;

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.transform.position.y > playerY)
        {
            playerY += yIncrease;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + yIncrease, this.transform.position.z);
        }
    }
}
