using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 

    Takes care of healthCounter/respawn updates.

*/

public class PlayerHealth : MonoBehaviour {

    public static int healthCounter;
    private bool invincible = false;
    public Text healthText = null;
    private Scene scene;

    void Start() {
        healthCounter = 20;
        healthText.text = "Health: " + healthCounter.ToString();
        healthText.enabled = true;
        this.scene = SceneManager.GetActiveScene();
    }

    void Update() {
        // Handles invincibility when enemy is hit or state is changed.
        if (invincible) StartCoroutine(Invulnerability());

        if (healthCounter <= 0) respawn();

    }

    private void respawn() { SceneManager.LoadScene(this.scene.name); }

    // Handles Collision
    private void OnTriggerEnter2D(Collider2D collision) {

        // If the player is hit by an enemy wielding the GoombaScript:
        if (collision.CompareTag("Enemy")) {

            healthCounter -= 1;
            healthText.text = "Health: " + healthCounter.ToString();
            invincible = true;

        }

    }

    // Invulnerability Iterator
    IEnumerator Invulnerability() {
        yield return new WaitForSeconds(3f);
        invincible = false;
    }

}
