using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {

        Vector3 temp = transform.position;
        
        // Set camera's x&y positions to the players.
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;
        transform.position = temp;

    }
}
