using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private bool jumpState = false;
    public float runSpeed = 80f;
    public float avgSpeed = 0f;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {

        avgSpeed = Input.GetAxis("Horizontal") * runSpeed;    

        if (Input.GetButtonDown("Jump")) {
            jumpState = true;
        }
        else {
            jumpState = false;
        }

        animator.SetBool("Jump", jumpState);
        animator.SetFloat("Speed", Mathf.Abs(avgSpeed));
        
    }

    void FixedUpdate() {

        // The two bools determine crouch state and jump state.  
        controller.Move(avgSpeed * Time.fixedDeltaTime, false, jumpState);
        jumpState = false;

    }

    void OnTriggerEnter2D(Collider2D other) {

        if((other.gameObject.tag == "Ladder") && jumpState) {

            Debug.Log("Touched ladder and Jump Key pressed.");

        }



    }

}
