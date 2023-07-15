using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private void Update()
    {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
