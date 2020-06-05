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

public class HeadlinesScript : MonoBehaviour
{
    private bool showOptions = false;
    private bool onlyDoOnce = true;
    private bool Once = true;
    private bool transition = false;
    private string trueHeadline;
    private string keyword;
    private string topic;
    private HeadlineData data;
    private GameObject gameLogic;
    public GameObject headlinesObject;
    public int waitTime = 10;
    private List<string> options = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
    private List<GameObject> buttons = new List<GameObject>();
    private List<int> indices;
    private string trueAnswer;
    private List<HeadlineScores> headlineScores;
    private JObject feedbackData = new JObject();
    private JObject hurryUpData = new JObject();
    private List<string> h_pf = new List<string>() { "Wat hebben jullie hard gewerkt!", "Wauw, deze score geeft jullie veel volgers!", "Jullie hebben flink jullie best gedaan, goed hoor!" };
    private List<string> h_nf = new List<string>() { "Denk in het volgende spel eraan dat iedereen van jullie team mee blijft doen!", "Was het lastig om de echte en neppe titels van elkaar te onderscheiden? Volgende keer beter!", "Let erop dat je genoeg met je teamleden blijft overleggen!", "Hoe ziet er echte titel er vaak uit? Bespreek het in jullie groepje." };


    // Start is called before the first frame update
    void Start()
    {
        // Add onMessage
        AirConsole.instance.onMessage += OnMessage;

        // Initialize some objects
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic");

        // Send button nr
        JObject buttonNr = new JObject();
        int nr = gameLogic.GetComponent<GameStats>().amountOfTeams() + 1;
        buttonNr.Add("buttonNr", nr);
        print("buttonnr: " + nr);
        foreach (var team in gameLogic.GetComponent<GameStats>().getTeams())
        {
            AirConsole.instance.Message(team.getTeamDeviceID(), buttonNr);
        }

        // Get buttons and set them to inactive
        for (int i = 1; i <= 9; i++)
        {
            GameObject currentButton = GameObject.FindGameObjectWithTag("Button " + i);
            currentButton.SetActive(false);
            buttons.Add(currentButton);
        }

        // Ask GameStats/AI Component for ´true headline and keyword to display it; Get a true headline and its keyword
        List<HeadlineData> headlinesList = getData();
        print("Amount of headlines questions left: " + headlinesList.Count);
        gameLogic.GetComponent<GamesData>().setHeadlineData(headlinesList);
        trueHeadline = data.getTrueHeadline();
        keyword = data.getKeyword();
        topic = data.getTopic();

        var topics = new Dictionary<string, string>()
        {
            {"showbusiness", "show business"},
            {"politics", "politiek"},
            {"actueel_nieuws", "actueel nieuws"},
            {"misdaad", "misdaad"},
            {"sport","sport"},
            {"klimaat", "klimaat"}
        };

        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> \n\n\n\n\n\n\n\n\n\n Bedenk een zo echt mogelijk klinkende titel voor een nieuwsbericht met het woord \n\n '" + keyword + "'\n\n  passend binnen het thema '" + topics[topic] + "'. \n\n De titel mag gaan over iets wat echt gebeurd is, maar mag geen bestaande titel zijn! </b>";
        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().fontSize = 52;
        // Send instructions to controller to change to Input layout
        gameLogic.GetComponent<AIComponent>().SetView("view-8");
    }

    private void OnMessage(int device_id, JToken data)
    {
        
        //For some reason it is always triggered twice... gotta fix that, stil works though bc doubling does not matter here lol 
        if (data != null && AirConsole.instance.IsAirConsoleUnityPluginReady() && data["headline"] != null)
        {
            string answer = (string) data["headline"];
            gameLogic.GetComponent<GameStats>().getTeam(device_id).setStringAnswer(answer);
            gameLogic.GetComponent<GameStats>().getTeam(device_id).setTeamReady(true);
            print("Device ID: " + device_id + ", answered with " + answer);
        }
        else if (data != null && AirConsole.instance.IsAirConsoleUnityPluginReady() && data["element"] != null)
        {
            // Get answers
            string answer = data["data"]["1"].ToString();
            gameLogic.GetComponent<GameStats>().getTeam(device_id).setStringAnswer(answer);
            print("Device ID: " + device_id + ", answered with " + answer);
            gameLogic.GetComponent<GameStats>().getTeam(device_id).setTeamReady(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Wait for all responses
        if (gameLogic.GetComponent<GameStats>().allTeamsReady() && !showOptions)
        {
            showOptions = true;
            GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> Vind de echte titel tussen de verzonnen titels van de andere teams. Je verdient bonuspunten als jullie titel geraden wordt door een van de teams! </b>";
            GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().fontSize = 32;

            // reset readiness
            foreach (var team in gameLogic.GetComponent<GameStats>().getTeams())
            {
                gameLogic.GetComponent<GameStats>().getTeam(team.getTeamDeviceID()).setTeamReady(false);
            }

            // Create list of all headlines

            // Shuffle answers
            indices = Enumerable.Range(0, gameLogic.GetComponent<GameStats>().amountOfTeams() + 1).ToList();
            Shuffle(indices);

            headlineScores = new List<HeadlineScores>();
            int i = 0;
            foreach (var team in gameLogic.GetComponent<GameStats>().getTeams())
            {
                int idx = indices[i];
                headlineScores.Add(new HeadlineScores(team.getTeamDeviceID(), team.getStringAnswer(), 0, options[idx], idx));
                buttons[idx].SetActive(true);
                string buttonText = "<b>" + options[idx] + "</b>: " + team.getStringAnswer();
                string tempString = "";
                foreach (char c in buttonText)
                {
                    char newC = c;
                    if (char.GetUnicodeCategory(c) == UnicodeCategory.SpaceSeparator) tempString += " ";
                    else tempString += newC;
                }
                buttons[idx].GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = tempString;
                print("device" + team.getTeamDeviceID() + " idx" + idx + " headline " + team.getStringAnswer());
                i++;
            }

            // Set true headline
            trueAnswer = options[indices[i]];
            buttons[indices[i]].SetActive(true);
            buttons[indices[i]].GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b>" + options[indices[i]] + "</b>: " + trueHeadline;

            print("set view to 4");
            // Send instructions to controller to change to Input layout
            gameLogic.GetComponent<AIComponent>().SetView("view-4");
            transition = true;
        }
        else if (gameLogic.GetComponent<GameStats>().halfTeamsReady() && transition)
        {
            foreach (string t in gameLogic.GetComponent<GameStats>().NotReadyTeams())
            {
                if (hurryUpData["hurryup"] == null)
                {
                    hurryUpData.Add("hurryup", "headlines_choose");
                }
                else
                {
                    hurryUpData["hurryup"] = "headlines_choose";
                }

                AirConsole.instance.Message(int.Parse(t), hurryUpData);
            }
            transition = false;
        }
        else if (gameLogic.GetComponent<GameStats>().allTeamsReady() && onlyDoOnce)
        {
            AIComponent ai = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>();
            string feedback = "false";
            // go through all teams 
            foreach (var team in gameLogic.GetComponent<GameStats>().getTeams())
            {
                // Check if the team voted for the true headline
                string answer = team.getStringAnswer();
                if (answer.Equals(trueAnswer))
                {
                    ai.addAIData(0.8f, 0.2f, true);
                    team.addScore(100);
                    foreach (HeadlineScores h in headlineScores)
                    {
                        if (h.DeviceId == team.getTeamDeviceID())
                        {
                            h.Score += 100;
                        }
                    }
                }
                // when the team did not pick the true headline, they can still get points if other teams voted for their headline
                else {
                    ai.addAIData(0.8f, 0.2f, false);
                    foreach (HeadlineScores h in headlineScores)
                    {
                        if (h.DeviceId == team.getTeamDeviceID())
                        {
                            h.TrueAnswer = false;
                        }
                        if(h.Option.Equals(answer) && h.DeviceId != team.getTeamDeviceID())
                        {
                            h.FooledTeams += 1;
                            gameLogic.GetComponent<GameStats>().getTeam(h.DeviceId).addScore(100);
                            h.Score += 100;
                        }
                    }
                }

            }

            // Send special feedback if people fooled other teams
            foreach (HeadlineScores h in headlineScores) 
            {
                feedback = "";
                System.Random rnd = new System.Random();
                if (h.TrueAnswer)
                    feedback += "Jullie antwoord was goed! &#9989 \r\n " + h_pf[rnd.Next(0, h_pf.Count-1)] + " \r\n  \r\n";
                else
                    feedback += "Jullie antwoord was helaas fout &#128549 \r\n \r\n" + h_nf[rnd.Next(0, h_pf.Count - 1)] + " \r\n \r\n ";

                if (h.FooledTeams > 0)
                {
                    feedback += "Je team heeft een aantal andere teams voor de gek gehouden, goed gedaan! &#9989 \r\n \r\n";
                }
                if (h.Score == 100)
                    feedback += "Je hebt &#128175 nieuwe volgers &#128525";
                else if (h.Score != 0)
                    feedback += "Je hebt " + h.Score + " nieuwe volgers &#128525";

                if (feedbackData["headlines"] == null)
                {
                    feedbackData.Add("headlines", feedback);
                }
                else
                {
                    feedbackData["headlines"] = feedback;
                }
                print(feedback);
                AirConsole.instance.Message(h.DeviceId, feedbackData);
            }

            // Show only true headline --> Get buttons and set them to inactive
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i != indices[indices.Count - 1])
                {
                    buttons[i].SetActive(false);
                }
            }
            GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> Dit is de echte! </b>";
            GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().fontSize = 72;

            // Wait for X seconds and go to next screen
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
                    hurryUpData.Add("hurryup", "headlines");
                }
                else
                {
                    hurryUpData["hurryup"] = "headlines";
                }

                AirConsole.instance.Message(int.Parse(t), hurryUpData);
            }
            Once = false;
        }
    }
    
    public void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = UnityEngine.Random.Range(0, list.Count);
            int tempGO = list[rnd];
            list[rnd] = list[i];
            list[i] = tempGO;
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

    private List<HeadlineData> getData()
    {
        //Remove all data without chosen topics
        string[] chosenTopics = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getChosenTopics();

        //Get the real fake data from data object
        List<HeadlineData> dataList = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GamesData>().getHeadlineData();

        List<HeadlineData> shuffledData = dataList.OrderBy(x => UnityEngine.Random.value).ToList();
        HeadlineData r;
        foreach (HeadlineData d in shuffledData)
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
