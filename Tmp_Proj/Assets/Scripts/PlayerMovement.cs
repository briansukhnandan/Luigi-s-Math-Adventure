using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public bool jumpState = false;
    public float runSpeed = 80f;
    public float avgSpeed = 0f;

    // Update is called once per frame
    void Update()
    {

        avgSpeed = Input.GetAxis("Horizontal") * runSpeed;    

        if (Input.GetButtonDown("Jump")) {
            jumpState = true;
        }
        
    }

    void FixedUpdate() {

        // The two bools determine crouch state and jump state.  
        controller.Move(avgSpeed * Time.fixedDeltaTime, false, jumpState);
        jumpState = false;

    }
}
