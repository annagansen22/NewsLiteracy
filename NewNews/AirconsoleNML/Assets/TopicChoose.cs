using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class TopicChoose : MonoBehaviour
{
    Tuple<string, int> sport = new Tuple<string, int> ("sport", 0 );
    Tuple<string, int> actueel_nieuws = new Tuple<string, int>("actueel_nieuws", 0);
    Tuple<string, int> showbusiness = new Tuple<string, int>("showbusiness", 0);
    Tuple<string, int> politiek = new Tuple<string, int>("politiek", 0);
    Tuple<string, int> klimaat = new Tuple<string, int>("klimaat", 0);
    Tuple<string, int> misdaad = new Tuple<string, int>("misdaad", 0);

    public void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        print("Amount of connected devices: " + AirConsole.instance.GetControllerDeviceIds().Count);
    }
    private bool noTopicsSet = true;

    private void OnMessage(int device_id, JToken data)
    {
        //For some reason it is always triggered twice... gotta fix that, stil works though bc doubling does not matter here lol 
        //Always check these things before doing onmessage...
        if (data != null && AirConsole.instance.IsAirConsoleUnityPluginReady() && data["element"] != null)
        {
            //A = Sport, B =  Politiek, C =  Actueel Nieuws, D = Klimaat, E = Showbusiness, F = Misdaad
            string answer = data["data"]["1"].ToString();
            print("Device ID: " + device_id + ", answered with " + answer);
            if (GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).getThreeVotes() > 0)
            {
                switch (answer)
                {
                    case "A":
                        voteSport();
                        break;
                    case "B":
                        votePolitiek();
                        break;
                    case "C":
                        voteActueel_nieuws();
                        break;
                    case "D":
                        voteKlimaat();
                        break;
                    case "E":
                        voteShowbusiness();
                        break;
                    case "F":
                        voteMisdaad();
                        break;
                    default:
                        break;
                }
                GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).decrementThreeVotes();
                if (GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).getThreeVotes() <= 0)
                {
                    GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).setTeamReady(true);
                }
            }
            
        }
        printCount();
    }
    public void voteSport()
    {
        int i = sport.Item2 + 1;
        sport = new Tuple<string, int>("sport", i);
    }
    public void voteActueel_nieuws()
    {
        int i = actueel_nieuws.Item2 + 1;
        actueel_nieuws = new Tuple<string, int>("actueel_nieuws", i);
    }

    public void voteShowbusiness()
    {
        int i = showbusiness.Item2 + 1;
        showbusiness = new Tuple<string, int>("showbusiness", i);
    }

    public void votePolitiek()
    {
        int i = politiek.Item2 + 1;
        politiek = new Tuple<string, int>("politiek", i);
    }

    public void voteKlimaat()
    {
        int i = klimaat.Item2 + 1;
        klimaat = new Tuple<string, int>("klimaat", i);
    }

    public void voteMisdaad()
    {
        int i = misdaad.Item2 + 1;
        misdaad = new Tuple<string, int>("misdaad", i);
    }

    public void printCount()
    {
        print(printTopic(sport));
        print(printTopic(actueel_nieuws));
        print(printTopic(showbusiness));
        print(printTopic(politiek));
        print(printTopic(klimaat));
        print(printTopic(misdaad));
    }

    private string printTopic(Tuple<string, int> x)
    {
        return (x.Item1 + ":" + x.Item2 + "\n");
    }

    public string[] getThreeTopics()
    {
        List<Tuple<string, int>> voteList = new List<Tuple<string, int>> { sport, actueel_nieuws, showbusiness, politiek, klimaat, misdaad };
        voteList.Sort((a, b) => b.Item2.CompareTo(a.Item2));
        List<Tuple<string, int>> sortedList = new List<Tuple<string, int>> { voteList[0], voteList[1], voteList[2] };
        string[] topicList = new string[3];
        int i = 0;
        foreach (Tuple<string, int> t in sortedList)
        {
            topicList[i] = t.Item1;
            print("Topic " + i + ": " + t.Item1);
            i += 1;
        }
        return topicList;
    }

    public void Update()
    {
        Progressbar progressbar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
        //if all teams are ready
        if (progressbar.allTeamsReady() && noTopicsSet)
        {
            setTopics();
            noTopicsSet = false;
        }
    }


    //Do this when all players voted
    public void setTopics()
    {
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setChosenTopics(getThreeTopics());
        AirConsole.instance.onMessage -= OnMessage;
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().nextScene(SceneManager.GetActiveScene().name);
    }
}
