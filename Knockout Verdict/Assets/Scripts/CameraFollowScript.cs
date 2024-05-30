using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private Vector3 offset = new Vector3 (0, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    public float SmoothTime = 0.5f;
    public Transform target;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
    }
}
