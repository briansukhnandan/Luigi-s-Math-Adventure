using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTriggerScript : MonoBehaviour
{

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        this.scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") {
            Debug.Log("Player touched Death Trigger, restarting scene.");
            SceneManager.LoadScene(this.scene.name);
        }

    }

    /* 
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
