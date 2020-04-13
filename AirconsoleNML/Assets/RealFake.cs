using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RealFake : MonoBehaviour
{
    void Start()
    {
        // Ask GameStats/AI Component for question to display and display it
        string sentence = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getRealFakeSentence();
        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> REAL OR FAKE? </b> \n\n " + sentence;

        // Send instructions to controller to change to "Yes or no layout"
        // TODO

        // Wait for all responses

        // Show answer

        // Wait for X seconds and go to next screen

    }

    void Update()
    {
        
    }
}
