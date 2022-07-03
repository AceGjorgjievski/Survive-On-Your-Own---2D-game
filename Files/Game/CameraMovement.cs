using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if(this.target != null)
        {
            Vector3 newPos = new Vector3(this.target.position.x, this.target.position.y + this.yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}
