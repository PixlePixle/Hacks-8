using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    [SerializeField]
    Vector2 offset;

    void FixedUpdate()
    {
        //Vector3 targetPosition = new Vector3(0, target.position.y + offset.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        if (target.position.x < 255) {
            transform.position = new Vector3(target.position.x + offset.x, offset.y, transform.position.z);
        }

    }
}

