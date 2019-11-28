using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionTrigger : MonoBehaviour {

    private string signMessage;
    public int signAnswer;
    public bool playerActivation = false;
    public Text DisplayText = null;
    private static Dictionary<string, int> mapOfQuestions = new Dictionary<string, int>();

    void Start() { }

    void Update() { }

    // Handles Collision
    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player") {

            Debug.Log("Player touched Q-Block");
            playerActivation = true;
            DisplayText.enabled = true;
            
            // If we are on the first scene, initialize our map.
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("1")) {
                
                // To prevent memory leak, clear the map when the difficulty changes
                mapOfQuestions.Clear();

                switch(PlayerDifficulty.difficulty) {

                    case "Easy":
                        fillEasy();
                        break;

                    case "Medium":
                        fillMedium();
                        break;

                    case "Hard":
                        fillHard();
                        break;

                    case "Brutal":
                        fillBrutal();
                        break;

                }
            
            }

            /* 
            
                The below handles if we start the game from a scene that's not one 
                (DEV TESTING).
                A normal player wouldn't reach this state under normal circumstances.
            
            */

            // If we aren't in Scene 1 and our map is empty.
            else if (!(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("1")) && (mapOfQuestions.Count == 0)) {

                mapOfQuestions.Add("What is 15*0?", 0);

            }

            int randIndex = Random.Range(0, mapOfQuestions.Count);

            this.signMessage = getRandomMessage(mapOfQuestions, randIndex);
            this.signAnswer = getRandomMessageAns(mapOfQuestions, randIndex);

            mapOfQuestions.Remove(this.signMessage);

            // When we have the values of the sign for the level, set our DisplayText
            // to the Key.
            DisplayText.text =  this.signMessage;

            // Destroy the object upon collision with the Player.
            Destroy(this.gameObject);

        }

    }

    private string getRandomMessage(Dictionary<string, int> x, int y) {
        int j = 0;
        foreach (var deux in x.Keys) {
            if (j == y) {
                Debug.Log("Message set to: "+deux);
                return deux;
            }
            j++;
        }
        return "Error";
    }

    private int getRandomMessageAns(Dictionary<string, int> x, int y) {
        int j = 0;
        foreach (var deux in x.Values) {
            if (j == y) {
                Debug.Log("Value set to: "+deux);
                return deux;
            }
            j++;
        }
        return 1;
    }

    private void fillEasy() {
                        mapOfQuestions.Add("What is 19%3 (mod)?", 1);
                        mapOfQuestions.Add("What is 2+2?", 4);
                        mapOfQuestions.Add("What is 45+73?", 118);
                        mapOfQuestions.Add("What is 175+36?", 211);
                        mapOfQuestions.Add("What is 243/3?", 81);
                        mapOfQuestions.Add("What is 120/2?", 60);
                        mapOfQuestions.Add("What is 45/5?", 9);
                        mapOfQuestions.Add("What is 96/6?", 16);
                        mapOfQuestions.Add("What is 15*16?", 240);
                        mapOfQuestions.Add("What is 5*8?", 40);
                        mapOfQuestions.Add("What is 100%20 (mod)?", 0);
                        mapOfQuestions.Add("What is 33+45?", 78);
                        mapOfQuestions.Add("What is 120-65?", 55);
    } 

    private void fillMedium() {
                        mapOfQuestions.Add("What is 9^3", 729);
                        mapOfQuestions.Add("What is 16^2", 256);
                        mapOfQuestions.Add("What is 6^3", 216);
                        mapOfQuestions.Add("What is (2^16)-1?", 65535);
                        mapOfQuestions.Add("What is (3^4)-41?", 40);
                        mapOfQuestions.Add("What is (7^2)+49-5?", 93);
                        mapOfQuestions.Add("What is the area of a triangle with base:7, height:6?", 21);
                        mapOfQuestions.Add("What is the area of a triangle with base:3, height:4?", 6);
                        mapOfQuestions.Add("What is the area of a square with side 6?", 36);
                        mapOfQuestions.Add("What is the volume of a cube with side 5?", 125);
                        mapOfQuestions.Add("What is the volume of a cube with side 3?", 27);
                        mapOfQuestions.Add("What is the volume of a cube with side 1?", 1);
    }

    private void fillHard() {

                        mapOfQuestions.Add("For (x^2 - 10x + 25), what is the value of X?", 5);
                        mapOfQuestions.Add("2x+5=17, solve for X:", 6);
                        mapOfQuestions.Add("For (x^2 - 18x + 81), what is the value of X?", 9);
                        mapOfQuestions.Add("2x-32=114, solve for X:", 73);
                        mapOfQuestions.Add("2x-76=34, solve for X:", 55);
                        mapOfQuestions.Add("5x-45=45, solve for X:", 18);
                        mapOfQuestions.Add("3z-22=56, solve for Z:", 26);
                        mapOfQuestions.Add("If x>0, what is a solution to (x^2 - 64)?", 8);

    }

    private void fillBrutal() {

                        mapOfQuestions.Add("Integrate: 2x+5, from 2 to 3:", 10);
                        mapOfQuestions.Add("Take the derivative of 8x^2+56, at x=10:", 160);
                        mapOfQuestions.Add("Take the derivative of x^2 + 5 at x=3.", 6);
                        mapOfQuestions.Add("Integrate: -2*cos(x), from pi/2 to pi:", 4);
                        mapOfQuestions.Add("Take the derivative of: 3x^2 + 7 at x=5:", 30);
                        mapOfQuestions.Add("Take the derivative of: 6 at x=5:", 0);
                        mapOfQuestions.Add("Take the derivative of: 1175x at x=5:", 1175);



    }

}
