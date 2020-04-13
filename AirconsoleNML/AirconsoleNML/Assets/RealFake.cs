using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealFake : MonoBehaviour
{
    private bool trueAnswer;
    private GameObject gameLogic;
    public GameObject stampObject;
    void Start()
    {
        // Initialize some objects
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic");

        // Ask GameStats/AI Component for question to display and display it
        string sentence = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getRealFakeSentence();
        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> REAL OR FAKE? </b> \n\n " + sentence;
        // ASK FOR TRUE ANSWER
        trueAnswer = true;

        // Send instructions to controller to change to "Yes or no layout"
        // TODO

    }

    void Update()
    {
        // Wait for all responses
        if (gameLogic.GetComponent<GameStats>().allTeamsReady())
        {
            // Show answer
            stampObject.GetComponent<StampScript>().showStamp(trueAnswer);

            // Wait for X seconds and go to next screen
            StartCoroutine(WaitForSecondsThenSwitchScene(5, "PickTopicsScene"));
        }
    }

    public IEnumerator WaitForSecondsThenSwitchScene(int sec, string scene)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(sec);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        SceneManager.LoadScene(scene);
    }
}
