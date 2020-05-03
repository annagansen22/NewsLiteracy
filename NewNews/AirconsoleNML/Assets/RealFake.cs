using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;

public class RealFake : MonoBehaviour
{
    private bool trueAnswer;
    private RealFakeData data;
    private bool onlyDoOnce = true;
    private GameObject gameLogic;
    public GameObject stampObject;

    void Start()
    {
        // Add onMessage
        AirConsole.instance.onMessage += OnMessage;

        // Initialize some objects
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic");

        // Ask GameStats/AI Component for question to display and display it
        List<RealFakeData> realFakeList = getData();
        print("Amount of realFake questions left: " + realFakeList.Count);
        gameLogic.GetComponent<GamesData>().setRealFakeData(realFakeList);
        string sentence = data.getQuestion();
        trueAnswer = data.getTruth();

        // Display question
        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> REAL OR FAKE? </b> \n\n " + sentence;

        // Send instructions to controller to change to "Yes or no layout"
        gameLogic.GetComponent<AIComponent>().SetView("view-2");
    }

    private void OnMessage(int device_id, JToken data)
    {
        //For some reason it is always triggered twice... gotta fix that, stil works though bc doubling does not matter here lol 
        //Always check these things before doing onmessage...
        if (data != null && AirConsole.instance.IsAirConsoleUnityPluginReady() && data["element"] != null)
        {
            bool answer = false;
            //if button true is pressed
            if (data["element"] != null && data["element"].ToString() == "view-2-section-0-element-0")
            {
                if (data["data"]["pressed"].ToString() == "True")
                {
                    answer = true;
                }
            }
            //else if button false is pressed
            //else if (data["element"] != null && data["element"].ToString() == "view-2-section-0-element-1")
            //{
            //    if (data["data"]["pressed"].ToString() == "True")
            //    {
            //        answer = false;
            //    }
            //}
            gameLogic.GetComponent<GameStats>().getTeam(device_id).setBoolAnswer(answer);
            gameLogic.GetComponent<GameStats>().getTeam(device_id).setTeamReady(true);
            print("Device ID: " + device_id + ", answered with " + answer);
        }
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
                if (answer == trueAnswer) t.addScore(100);
            }

            // Wait for X seconds and go to next screen
            onlyDoOnce = false;
            AirConsole.instance.onMessage -= OnMessage;
            StartCoroutine(WaitForSecondsThenSwitchScene(5));
        }
    }

    public IEnumerator WaitForSecondsThenSwitchScene(int sec)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(sec);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().nextScene(SceneManager.GetActiveScene().name);
    }

    private List<RealFakeData> getData()
    {
        //Remove all data without chosen topics
        string[] chosenTopics = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getChosenTopics();

        //Get the real fake data from data object
        List<RealFakeData> dataList = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GamesData>().getRealFakeData();

        List<RealFakeData> shuffledData = dataList.OrderBy(x => UnityEngine.Random.value).ToList();
        RealFakeData r;
        foreach (RealFakeData d in shuffledData)
        {
            string topic = d.getTopic();
            if (topic == chosenTopics[0] || topic == chosenTopics[1] || topic == chosenTopics[2])
            {
                data = d;
                shuffledData.Remove(d);
                return shuffledData;
            }
        }    
        return shuffledData;
    }
}

//data = new List<RealFakeData>() { 
//    new RealFakeData("showbusiness",
//    "Klopt het dat je na een deelname aan temptation island niet meer mee mag doen aan programma's zoals ex on the beach?",
//    false),
//    new RealFakeData("showbusiness",
//    "Mag het Eurovisie songfestival komende jaren nog wel in Nederland gehouden worden vanwege het corona virus?",
//    true),
//    new RealFakeData("politics",
//    "Bestaat de harde kern van de PvdA uit laagopgeleide arbeiders?",
//    false),
//    new RealFakeData("politics",
//    "Heeft de PVV linkse standpunten gehad in de afgelopen jaren?",
//    true),
//    new RealFakeData("actueel_nieuws",
//    "Wordt het corona virus in stand gehouden door het nieuwe 5G netwerk?",
//    false),
//    new RealFakeData("actueel_nieuws",
//    "Zal de eikenprocessierups dit jaar nog meer overlast veroorzaken dan vorig jaar dankzij het heersende corona virus? ",
//    true),
//    new RealFakeData("klimaat",
//    "Zijn vliegtuigstrepen 'goed' voor het klimaat?",
//    false)
//};
