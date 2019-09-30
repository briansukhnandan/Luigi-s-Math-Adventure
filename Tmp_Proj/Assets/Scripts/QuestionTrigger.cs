using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTrigger : MonoBehaviour
{

    private string signMessage;
    public int signAnswer;
    public bool playerActivation = false;

    public Text DisplayText = null;

    Dictionary<string, int> mapOfQuestions = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        /* -----------------Initialize---------------------- */
        mapOfQuestions.Add("2x+5=17, solve for X:", 6);
        mapOfQuestions.Add("Integrate: 2x+5, from 2 to 3:", 10);
        mapOfQuestions.Add("For (x^2 - 10x + 25), what is the value of X?", 5);
        /* ------------------------------------------------ */

        // Debug.Log(mapOfQuestions.Count);

        // System.Random r = new Random();
        int randIndex = Random.Range(0, mapOfQuestions.Count);
        // Debug.Log("Randindex:"+randIndex);

        this.signMessage = getRandomMessage(mapOfQuestions, randIndex);
        this.signAnswer = getRandomMessageAns(mapOfQuestions, randIndex);

        // When we have the values of the sign for the level, set our DisplayText
        // to the Key.
        DisplayText.text =  this.signMessage;
        DisplayText.enabled = false;

        // Debug.Log("DisplayText: "+DisplayText.text);
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched Q-Block");
            playerActivation = true;
            DisplayText.enabled = true;
        }

    }

    /* 
    // Update is called once per frame
    void Update()
    {
        
    } 
    */

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

}
