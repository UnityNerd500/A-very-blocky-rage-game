using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Public Variables
    [Header("Assignables")]
    public Transform playerPosition;

    [Space()]

    [Header("Attributes")]
    public Vector3 offset;

    void Update()
    {
        // We calculate our camera's follow position
        transform.position = playerPosition.transform.position - offset;
    }
}
