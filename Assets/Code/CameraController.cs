using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public float distance;

    private void Update()
    {
        transform.position = target.position;
        transform.position = transform.position - transform.forward * distance;
    }

}