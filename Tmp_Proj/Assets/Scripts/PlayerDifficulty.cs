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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("med_diff"))
        {
            Debug.Log("Difficulty set to Medium");
            difficulty = "Medium";
        }

        if (collision.CompareTag("hard_diff"))
        {
            Debug.Log("Difficulty set to Hard");
            difficulty = "Hard";
        }

        if (collision.CompareTag("brutal_diff"))
        {
            Debug.Log("Difficulty set to Brutal");
            difficulty = "Brutal";
        }


    }

}
