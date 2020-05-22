using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.UI;

public class HeadlinesScript : MonoBehaviour
{
    private bool showOptions = false;
    private bool onlyDoOnce = true;
    private string trueHeadline;
    private string keyword;
    private string topic;
    private HeadlineData data;
    private GameObject gameLogic;
    public GameObject headlinesObject;
    public int waitTime = 1;
    private List<string> options = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
    private List<GameObject> buttons = new List<GameObject>();
    private List<int> indices;
    private string trueAnswer;
    private List<HeadlineScores> headlineScores;
    private JObject feedbackData = new JObject();

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
            {"showbusiness", "beroemdheden"},
            {"politics", "politiek"},
            {"actueel_nieuws", "actueel nieuws"},
            {"misdaad", "misdaad"},
            {"sport","sport"},
            {"klimaat", "klimaat"}
        };

        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> \n\n\n\n\n\n Bedenk je eigen nep titel met het trefwoord '" + keyword + "' met het onderwerp '" + topics[topic] + "'. \n\n Houd de anderen voor de gek door te geloven dat het echt is! </b>";
        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().fontSize = 72;
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
            GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b> Welke van deze nieuwskoppen is afkomstig van een echt nieuwsartikel en is dus niet door een van de teams verzonnen? </b>";
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
                buttons[idx].GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b>" + options[idx] + "<b>: " + team.getStringAnswer();
                print("device" + team.getTeamDeviceID() + " idx" + idx + " headline " + team.getStringAnswer());
                i++;
            }

            // Set true headline
            trueAnswer = options[indices[i]];
            buttons[indices[i]].SetActive(true);
            buttons[indices[i]].GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "<b>" + options[indices[i]] + "<b>: " + trueHeadline;

            print("set view to 4");
            // Send instructions to controller to change to Input layout
            gameLogic.GetComponent<AIComponent>().SetView("view-4");
        }
        else if (gameLogic.GetComponent<GameStats>().allTeamsReady() && onlyDoOnce)
        {
            AIComponent ai = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>();
            string feedback = "false";
            foreach (var team in gameLogic.GetComponent<GameStats>().getTeams())
            {
                string answer = team.getStringAnswer();
                if (answer.Equals(trueAnswer))
                {
                    ai.addAIData(0.8f, 0.2f, true);
                    team.addScore(100);
                    feedback = "true";
                    if (feedbackData["headlines"] == null)
                    {
                        feedbackData.Add("headlines", feedback);
                    }
                    else
                    {
                        feedbackData["headlines"] = feedback;
                    }
                    AirConsole.instance.Message(team.getTeamDeviceID(), feedbackData);
                }
                else {
                    ai.addAIData(0.8f, 0.2f, false);
                    foreach (HeadlineScores h in headlineScores)
                    {
                        if(h.Option.Equals(answer))
                        {
                            h.FooledTeams += 1;
                            gameLogic.GetComponent<GameStats>().getTeam(h.DeviceId).addScore(100);
                        }
                    }
                    if (feedbackData["headlines"] == null)
                    {
                        feedbackData.Add("headlines", feedback);
                    }
                    else
                    {
                        feedbackData["headlines"] = feedback;
                    }
                    AirConsole.instance.Message(team.getTeamDeviceID(), feedbackData);
                }

            }

            foreach (HeadlineScores h in headlineScores) 
            { 
                if(h.FooledTeams > 2)
                {
                    feedback = "fooled";
                    if (feedbackData["headlines"] == null)
                    {
                        feedbackData.Add("headlines", feedback);
                    }
                    else
                    {
                        feedbackData["headlines"] = feedback;
                    }
                }
            }

            // Wait for X seconds and go to next screen
            onlyDoOnce = false;
            AirConsole.instance.onMessage -= OnMessage;
            StartCoroutine(WaitForSecondsThenSwitchScene(waitTime));
        }
    }
    
    public void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(0, list.Count);
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
