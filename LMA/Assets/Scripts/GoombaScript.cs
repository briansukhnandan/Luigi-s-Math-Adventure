using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaScript : MonoBehaviour
{

    private Transform trans;
    public float speed = 4.0f;

    private bool dirRight = false;

    void Start() { trans = this.transform; }

    void reverseDirection() { dirRight = !dirRight; }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Goomba_Bound")) reverseDirection();
    }

    void Update() {

        if (dirRight) transform.Translate(speed * Time.deltaTime, 0f, 0f);
        else transform.Translate(-1 * speed * Time.deltaTime, 0f, 0f);
        
    }

}
