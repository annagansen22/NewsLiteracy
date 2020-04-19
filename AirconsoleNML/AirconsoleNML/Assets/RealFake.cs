﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealFake : MonoBehaviour
{
    private bool trueAnswer;
    private bool onlyDoOnce = true;
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
        if (gameLogic.GetComponent<GameStats>().allTeamsReady() && onlyDoOnce)
        {
            // Show answer
            stampObject.GetComponent<StampScript>().showStamp(trueAnswer);

            //Gather answers and give points
            foreach (Team t in GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeams())
            {
                bool answer = t.getBoolAnswer();
                if (answer == trueAnswer) t.addScore(50);
            }

            // Wait for X seconds and go to next screen
            onlyDoOnce = false;
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
