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
    public int door1 = 0;
    public int door2 = 0;
    public int door3 = 0;

    public GameObject topDoor;
    public GameObject middleDoor;
    public GameObject bottomDoor;

    private NextLevelDoorTrigger door1Trigger;
    private NextLevelDoorTrigger door2Trigger;
    private NextLevelDoorTrigger door3Trigger;

    // Start is called before the first frame update
    void Start()
    {
        QTrigger = QBox.GetComponent<QuestionTrigger>();

        door1Trigger = topDoor.GetComponent<NextLevelDoorTrigger>();
        door2Trigger = middleDoor.GetComponent<NextLevelDoorTrigger>();
        door3Trigger = bottomDoor.GetComponent<NextLevelDoorTrigger>();

        AnswerText.enabled = false;
        // Debug.Log(QTrigger.signAnswer);
        
    }

    void Update()
    {
        // If the player touched the QBox already.
        if (QTrigger.playerActivation) {

            int[] possibleChoices = {
                QTrigger.signAnswer+3,
                QTrigger.signAnswer+1,
                (2 * QTrigger.signAnswer) + 3,
                (-1 * QTrigger.signAnswer) + 2,
                (3 * QTrigger.signAnswer) + 1,
                QTrigger.signAnswer,
                (7 * QTrigger.signAnswer) - 5,
                (10 * QTrigger.signAnswer),
                (2 * QTrigger.signAnswer),
            };

            // TODO (Picking answers)
            // Pick random numbers for all the doors
            // On the last door, if the answer has been picked already
            // Else, Make the last door the answer.
            // For reference: There are 3 doors per level.

            AnswerText.text = doorInitializer(possibleChoices, door1, door2, door3);
            AnswerText.enabled = true;

            // Debug.Log("");
            // Debug.Log("QTrigger: "+QTrigger.signAnswer);
            Destroy(this.gameObject);
            // this.enabled = false;
            // GetComponent<BoxCollider2D>().enabled = false;
        }
        
    } 

    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched Ans-Block");
            // GetComponent<BoxCollider2D>().enabled = false;
            // AnswerText.enabled = true;
        }

    }

    // x refers to our possibleChoices array,
    // a,b,c are the door values respectively.
    private string doorInitializer(int[] x, int a, int b, int c) {

        for (int i = 0; i < x.Length; i++) {

            int r = Random.Range(0, x.Length);

            switch (i) {
                case 0:

                    r = Random.Range(0, x.Length);

                    // If the answer picked for the first door is the correct one.
                    // set answerPicked to true.
                    a = x[r];

                    if (a == QTrigger.signAnswer) answerPicked = true;
                    break;

                case 1:

                    // Get a new random number.
                    r = Random.Range(0, x.Length);

                    // If the answer picked for the second door is the correct answer
                    // and the answer was picked already for a previous door.
                    // Make a new random number and set b = to the door's value.
                    // If not, this means the rand int is the correct ans and
                    // the correct answer was not yet placed. Set b to this value.

                    if ((r == QTrigger.signAnswer)) {
                        if (answerPicked) {
                            r = Random.Range(0, x.Length);
                            if (r == QTrigger.signAnswer) r = Random.Range(0, x.Length); 
                            b = x[r];
                            b+=3;
                        }
                        else {

                            b = x[r];
                            answerPicked = true;

                        }
                        
                    }
                    else {
                        b = x[r];
                    }
                    break;

                // If the answer was not yet picked, set c to the answer.
                // Else, make a new random int and set c to the value at the index.
                case 2:

                    if (!answerPicked) {
                        c = QTrigger.signAnswer;
                    }
                    else {
                        r = Random.Range(0, x.Length);
                        if (r == QTrigger.signAnswer) r = Random.Range(0, x.Length);                
                        c = x[r];
                    }
                    break;

                default:
                    Debug.Log("Reached default block.");
                    break;


            }

        }

        string final = "Top Door: "+a.ToString()+"\n"+
                       "Middle Door: "+b.ToString()+"\n"+
                       "Bottom Door: "+c.ToString();

        this.door1 = a;
        this.door2 = b;
        this.door3 = c;

        door1Trigger.topDoorValue = a;
        door2Trigger.midDoorValue = b;
        door3Trigger.botDoorValue = c;

        door1Trigger.answerKey = QTrigger.signAnswer;
        door2Trigger.answerKey = QTrigger.signAnswer;
        door3Trigger.answerKey = QTrigger.signAnswer;

        return final;
    }
}
