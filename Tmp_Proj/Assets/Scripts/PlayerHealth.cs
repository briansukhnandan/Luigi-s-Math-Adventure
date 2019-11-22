using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 

    Takes care of healthCounter updates.

*/

public class PlayerHealth : MonoBehaviour
{

    public static int healthCounter;

    private bool invincible = false;

    public Text healthText = null;

    // Start is called before the first frame update
    void Start()
    {
        healthCounter = 3;
        healthText.text = "Health: " + healthCounter.ToString();
        healthText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Handles invincibility when enemy is hit or state is changed.
        if (invincible) 
            StartCoroutine(Invulnerability()); 
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        // If the player is hit by an enemy wielding the GoombaScript:
        if (collision.CompareTag("Enemy"))
        {

            healthCounter -= 1;
            healthText.text = "Health: " + healthCounter.ToString();
            invincible = true;

        }


    }

    IEnumerator Invulnerability() {
        yield return new WaitForSeconds(3f);
        invincible = false;
    }

}
