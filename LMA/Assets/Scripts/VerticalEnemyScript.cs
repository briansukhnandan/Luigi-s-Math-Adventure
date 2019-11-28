using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemyScript : MonoBehaviour {
    
    private Transform trans;
    public float speed = 4.0f;
    private bool dirUp = false;

    void reverseDirection() { dirUp = !dirUp; }

    void Start() { trans = this.transform; }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Goomba_Bound")) reverseDirection(); 
    
    }

    void Update() {

        if (dirUp) transform.Translate(0f, speed * Time.deltaTime, 0f);
        else transform.Translate(0f, -1 * speed * Time.deltaTime, 0f);
            
    }

}
