using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerTrigger : MonoBehaviour
{
    public GameObject QBox;
    private QuestionTrigger QTrigger;

    public Text AnswerText = null;

    public bool answerPicked = false;

    // Values for the doors to be overwritten.
    int door1 = 0;
    int door2 = 0;
    int door3 = 0;

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
            };

            // TODO (Picking answers)
            // Pick random numbers for all the doors
            // On the last door, if the answer has been picked already
            // Else, Make the last door the answer.
            // For reference: There are 3 doors per level.

            AnswerText.text = doorInitializer(possibleChoices, door1, door2, door3);
            

            // Debug.Log("QTrigger: "+QTrigger.signAnswer);
        }
        
    } 

    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched Ans-Block");
            
        }

    }

    // x refers to our possibleChoices array,
    // a,b,c are the door values respectively.
    private string doorInitializer(int[] x, int a, int b, int c) {

        for (int i = 0; i < x.Length; i++) {

            int r = Random.Range(0, x.Length);

            switch (i) {
                case 0:

                    // If the answer picked for the first door is the correct one.
                    // set answerPicked to true.
                    a = r;

                    if (a == QTrigger.signAnswer) answerPicked = true;

                case 1:

                    // Get a new random number.
                    r = Random.Range(0, x.Length);

                    // If the answer picked for the second door is the correct answer
                    // and the answer was picked already for a previous door.
                    // Make a new random number and set b = to the door's value.

                    if ((r == QTrigger.signAnswer) && (answerPicked)) {
                        r = Random.Range(0, x.Length);
                        b = r;
                    }

                    else if () {

                        

                    }


                case 2:

            }

        }



        return "0";
    }
}
