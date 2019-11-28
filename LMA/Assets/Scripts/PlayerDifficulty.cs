using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDifficulty : MonoBehaviour
{

    public static string difficulty;

    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("Difficulty Initialized to Easy.");
        difficulty = "Easy";       
    }

    void Update() { }

    private void OnTriggerEnter2D(Collider2D collision) {

        /* 

            Handles difficulty switching

        */

        if (collision.CompareTag("med_diff")) { difficulty = "Medium"; }
        if (collision.CompareTag("hard_diff")) { difficulty = "Hard"; }
        if (collision.CompareTag("brutal_diff")) { difficulty = "Brutal"; }

    }

}
