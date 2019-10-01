using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeachScript : MonoBehaviour
{

    public Text peachText;

    // Start is called before the first frame update
    void Start()
    {
        peachText.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player activated Peach text.");
            peachText.enabled = true;
        }

    }

    void OnTriggerExit2D(Collider2D other) {
        peachText.enabled = false;
    }

}
