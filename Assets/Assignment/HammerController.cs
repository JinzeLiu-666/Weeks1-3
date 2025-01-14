using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public GameObject hammerA;
    public GameObject hammerB;

    void Start()
    {

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
            hammerA.SetActive(false);
            hammerB.SetActive(true);
        }
        else
        {
            hammerA.SetActive(true);
            hammerB.SetActive(false);
        }
    }
}
