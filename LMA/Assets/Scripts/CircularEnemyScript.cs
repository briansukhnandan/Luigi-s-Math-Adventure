using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularEnemyScript : MonoBehaviour {

    private Transform trans;
    public float speed = 4.0f;

    private bool moveNorth = false;
    private bool moveSouth = false;
    private bool moveEast = false;
    private bool moveWest = false;

    // Start is called before the first frame update
    void Start() {
        trans = this.transform;

        // Upon start, have the sprite move to the left.
        moveWest = true;
    }

    // Update is called once per frame
    void Update() {

        if (moveEast) moveRight();
        else if (moveWest) moveLeft();
        else if (moveNorth) moveUp();
        else if (moveSouth) moveDown();
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        /* 
        
            The enemy will move in a clockwise square pattern.
            Each Tag represents a corner of that square, and will
            move the direction of the sprite accordingly.
        
        */

        if (other.gameObject.CompareTag("Circular_Top_Left")) {
            moveEast = true;

            moveNorth = false;
            moveSouth = false;
            moveWest = false;
        }

        if (other.gameObject.CompareTag("Circular_Top_Right")) {
            moveSouth = true;

            moveNorth = false;
            moveWest = false;
            moveEast = false;
        }

        if (other.gameObject.CompareTag("Circular_Bottom_Right")) {
            moveWest = true;

            moveNorth = false;
            moveSouth = false;
            moveEast = false;
        }

        if (other.gameObject.CompareTag("Circular_Bottom_Left")) {
            moveNorth = true;

            moveSouth = false;
            moveEast = false;
            moveWest = false;
        }
        
    }

    private void moveRight() { transform.Translate(speed * Time.deltaTime, 0f, 0f); }
    private void moveLeft() { transform.Translate(-1 * speed * Time.deltaTime, 0f, 0f); }
    private void moveUp() { transform.Translate(0f, speed * Time.deltaTime, 0f); }
    private void moveDown() { transform.Translate(0f, -1 * speed * Time.deltaTime, 0f); }

}
