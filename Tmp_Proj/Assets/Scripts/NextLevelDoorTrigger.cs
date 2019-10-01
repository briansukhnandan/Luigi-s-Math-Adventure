using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoorTrigger : MonoBehaviour
{

    public GameObject AnswerBox;
    public int answerKey;
    private AnswerTrigger Answers;

    private Scene scene;

    // Tick the corresponding box in the Unity Editor
    public bool topDoor;
    public bool midDoor;
    public bool botDoor;

    public int topDoorValue = 0;
    public int midDoorValue = 0;
    public int botDoorValue = 0;

    // Start is called before the first frame update
    void Start()
    {

        Answers = AnswerBox.GetComponent<AnswerTrigger>();

        this.scene = SceneManager.GetActiveScene();

        // if (topDoor) Debug.Log("Top Door initialized to value: "+Answers.door1);
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player")
        {
            // If the top door was touched.
            if (topDoor) {
                Debug.Log("Player touched top door");
                // If the value of the top door is our answer.
                if (topDoorValue == answerKey) {
                    Debug.Log("Correct Answer Selected");
                }
                // Else
                else {
                    Debug.Log("Incorrect Answer selected");
                    SceneManager.LoadScene(this.scene.name);
                }
            }

            if (midDoor) {
                Debug.Log("Player touched mid door");

                // If the value of the mid door is our answer.
                if (midDoorValue == answerKey) {
                    Debug.Log("Correct Answer Selected");
                }
                else {
                    Debug.Log("Incorrect Answer selected");
                    SceneManager.LoadScene(this.scene.name);
                }
            }
            if (botDoor) {
                Debug.Log("Player touched bot door");
                // If the value of the bot door is our answer.
                if (botDoorValue == answerKey) {
                    Debug.Log("Correct Answer Selected");
                }
                else {
                    Debug.Log("Incorrect Answer selected");
                    SceneManager.LoadScene(this.scene.name);
                }
            }

        }

    }

    /* 
    // Update is called once per frame
    void Update()
    {

        // if (topDoorValue > 0) Debug.Log("Top Door Value"+topDoorValue);
        
    }
    */
}
