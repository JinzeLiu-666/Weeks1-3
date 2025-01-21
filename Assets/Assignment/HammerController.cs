using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    private float rotationAngle = 10f; // 

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, 0, rotationAngle);
    }

    void Update()
    {
        // Get the mouse position and update the game position
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        transform.position = worldPosition;

        // Mouse click to switch hammer
        if (Input.GetMouseButton(0))
        {
            transform.rotation = targetRotation;
        }
        else
        {
            transform.rotation = initialRotation;
        }
    }
}
