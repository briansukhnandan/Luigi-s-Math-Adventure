using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerTrigger : MonoBehaviour
{
    public GameObject QBox;
    private QuestionTrigger QTrigger;

    // Start is called before the first frame update
    void Start()
    {
        QTrigger = QBox.GetComponent<QuestionTrigger>();

        // Debug.Log(QTrigger.signAnswer);
        
    }

    void Update()
    {
        // If the player touched the QBox already.
        if (QTrigger.playerActivation) {

            int[] possibleChoices = {

                (2 * QTrigger.signAnswer) + 3,
                QTrigger.signAnswer,
                (4 * QTrigger.signAnswer) - 10,

            }

            // TODO (Picking answers)
            // Pick random numbers for all the doors
            // On the last door, if the answer has been picked already
            // Else, Make the last door the answer.

            // Debug.Log("QTrigger: "+QTrigger.signAnswer);
        }
        
    } 

    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched Ans-Block");
            
        }

    }
}
