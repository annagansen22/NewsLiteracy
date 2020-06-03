using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.UI;
using System.Globalization;
using System;

public class MatchingScript : MonoBehaviour
{
    private bool onlyDoOnce = true;
    private MatchingData data;
    Dictionary<string, string> dict;
    private GameObject gameLogic;
    public int waitTime = 10;
    private JObject feedbackData = new JObject();
    private JObject hurryUpData = new JObject();
    private JObject viewData = new JObject();
    private bool Once = true;
    private List<string> purposes;

    // Start is called before the first frame update
    void Start()
    {
        // Add onMessage
        AirConsole.instance.onMessage += OnMessage;

        // Initialize some objects
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic");

        // Ask GameStats/AI Component for matching data
        List<MatchingData> matchingList = getData();
        print("Amount of headlines questions left: " + matchingList.Count);
        gameLogic.GetComponent<GamesData>().setMatchingData(matchingList);

        // extract dictionary
        dict = data.getDict();
        purposes = dict.Values.ToList();
        purposes = purposes.OrderBy(x => UnityEngine.Random.value).ToList();

        // Set text
        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "\n\n Match de " + data.getItem2() + " aan de " + data.getItem1() + " door A, B, C en D op de juiste volgorde aan te klikken op je scherm!";

        // Set Headlines in correct order
        IEnumerator<string> headlinesEnumerator = dict.Keys.GetEnumerator();
        headlinesEnumerator.MoveNext();
        GameObject.FindGameObjectWithTag("Headline 1").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> 1 </b>: " + headlinesEnumerator.Current;
        headlinesEnumerator.MoveNext();
        GameObject.FindGameObjectWithTag("Headline 2").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> 2 </b>: " + headlinesEnumerator.Current;
        headlinesEnumerator.MoveNext();
        GameObject.FindGameObjectWithTag("Headline 3").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> 3 </b>: " + headlinesEnumerator.Current;
        headlinesEnumerator.MoveNext();
        GameObject.FindGameObjectWithTag("Headline 4").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> 4 </b>: " + headlinesEnumerator.Current;

        // Set Purposes in mixed order
        IEnumerator<string> purposesEnumerator = purposes.GetEnumerator();
        purposesEnumerator.MoveNext();
        GameObject.FindGameObjectWithTag("Source A").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> A </b>: " + purposesEnumerator.Current;
        purposesEnumerator.MoveNext();
        GameObject.FindGameObjectWithTag("Source B").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> B </b>: " + purposesEnumerator.Current;
        purposesEnumerator.MoveNext();
        GameObject.FindGameObjectWithTag("Source C").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> C </b>: " + purposesEnumerator.Current;
        purposesEnumerator.MoveNext();
        GameObject.FindGameObjectWithTag("Source D").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> D </b>: " + purposesEnumerator.Current;

        // Send instructions to controller to change to Input layout
        gameLogic.GetComponent<AIComponent>().SetView("view-5");
    }

    // Update is called once per frame
    void Update()
    {
        // Wait for all responses
        if (gameLogic.GetComponent<GameStats>().allTeamsReady() && onlyDoOnce)
        {
            // Show correct order of matching
            GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> Dat is de juiste match! </b>";
            Dictionary<int, string> intToLetter = new Dictionary<int, string>() {
            {0, "A"}, {1, "B"}, {2, "C"}, {3, "D"}};
            IEnumerator<string> matchesEnumerator = dict.Values.GetEnumerator();
            matchesEnumerator.MoveNext();
            int idx = purposes.IndexOf(matchesEnumerator.Current);
            GameObject.FindGameObjectWithTag("Source A").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> " + intToLetter[idx] + " </b>: " + matchesEnumerator.Current;
            matchesEnumerator.MoveNext();
            idx = purposes.IndexOf(matchesEnumerator.Current);
            GameObject.FindGameObjectWithTag("Source B").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> " + intToLetter[idx] + " </b>: " + matchesEnumerator.Current;
            matchesEnumerator.MoveNext();
            idx = purposes.IndexOf(matchesEnumerator.Current);
            GameObject.FindGameObjectWithTag("Source C").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> " + intToLetter[idx] + " </b>: " + matchesEnumerator.Current;
            matchesEnumerator.MoveNext();
            idx = purposes.IndexOf(matchesEnumerator.Current);
            GameObject.FindGameObjectWithTag("Source D").GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b> " + intToLetter[idx] + " </b>: " + matchesEnumerator.Current;


            AIComponent ai = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>();

            //Gather answers and give points
            foreach (Team t in GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeams())
            {
                string feedback = "false";
                List<int> matches = t.getMatches();
                List<string> m = new List<string>() { purposes[matches[0]], purposes[matches[1]], purposes[matches[2]], purposes[matches[3]] };
                print("answers: ");
                foreach (string i in m)
                {
                    print(i);
                }
                print("values:");
                foreach (string j in dict.Values.ToList())
                {
                    print(j);
                }
                if (dict.Values.ToList().SequenceEqual(m))
                {
                    //When the team gave a correct answer
                    ai.addAIData(1.0f, 0.0f, true);
                    t.addScore(100);
                    feedback = "true";
                    if (feedbackData["matching"] == null)
                    {
                        feedbackData.Add("matching", feedback);
                    }
                    else
                    {
                        feedbackData["matching"] = feedback;
                    }
                    AirConsole.instance.Message(t.getTeamDeviceID(), feedbackData);
                }
                else
                {
                    //When the team gave a wrong answer
                    ai.addAIData(1.0f, 0.0f, false);
                    if (feedbackData["matching"] == null)
                    {
                        feedbackData.Add("matching", feedback);
                    }
                    else
                    {
                        feedbackData["matching"] = feedback;
                    }
                    AirConsole.instance.Message(t.getTeamDeviceID(), feedbackData);
                }
            }

            // Wait for X seconds and go to next screen
            foreach (Team t in GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeams())
            {
                GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(t.getTeamDeviceID()).clearMatches();
            }
            onlyDoOnce = false;
            AirConsole.instance.onMessage -= OnMessage;
            StartCoroutine(WaitForSecondsThenSwitchScene(waitTime));
        }
        else if (gameLogic.GetComponent<GameStats>().halfTeamsReady() && Once)
        {
            foreach (string t in gameLogic.GetComponent<GameStats>().NotReadyTeams())
            {
                if (hurryUpData["hurryup"] == null)
                {
                    hurryUpData.Add("hurryup", "matching");
                }
                else
                {
                    hurryUpData["hurryup"] = "matching";
                }

                AirConsole.instance.Message(int.Parse(t), hurryUpData);
            }
            Once = false;
        }
    }

    private void OnMessage(int device_id, JToken data)
    {
        //For some reason it is always triggered twice... gotta fix that, stil works though bc doubling does not matter here lol 
        //Always check these things before doing onmessage...
        if (data != null && AirConsole.instance.IsAirConsoleUnityPluginReady() && data["element"] != null)
        {
            string answer = data["data"]["1"].ToString();
            print("Device ID: " + device_id + ", answered with " + answer);
            Team team = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id);
            if (GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).hasMatchedAll()) return;
            switch (answer)
            {
                case "A":
                    team.voteMatch(0);
                    break;
                case "B":
                    team.voteMatch(1);
                    break;
                case "C":
                    team.voteMatch(2);
                    break;
                case "D":
                    team.voteMatch(3);
                    break;
            }

            if (GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).hasMatchedAll())
            {
                gameLogic.GetComponent<GameStats>().getTeam(device_id).setTeamReady(true);
                // set controller view to waiting
                if (viewData["view"] == null)
                {
                    viewData.Add("view", "view-10");
                }
                AirConsole.instance.Message(device_id, viewData);
            }
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

    private List<MatchingData> getData()
    {
        //Remove all data without chosen topics
        string[] chosenTopics = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getChosenTopics();

        //Get the real fake data from data object
        List<MatchingData> dataList = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GamesData>().getMatchingData();

        List<MatchingData> shuffledData = dataList.OrderBy(x => UnityEngine.Random.value).ToList();
        MatchingData d = shuffledData[0];
        data = d;
        shuffledData.Remove(d);
        return shuffledData;
    }
}
