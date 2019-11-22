using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaScript : MonoBehaviour
{

    private Transform trans;
    public float speed = 4.0f;

    private bool dirRight = false;

    // Start is called before the first frame update
    void Start()
    {
        trans = this.transform;
    }

    void OnTriggerEnter2D(Collider2D other) {

        // Debug.Log("Something touched trigger");

        if (other.gameObject.CompareTag("Goomba_Bound")) {
            reverseDirection();
        }

        

    }

        
    // Update is called once per frame
    void Update()
    {

        if (dirRight) {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        else {
            transform.Translate(-1 * speed * Time.deltaTime, 0f, 0f);
        }
        
    }
    

    void reverseDirection() {
        
        dirRight = !dirRight;

    }

}
