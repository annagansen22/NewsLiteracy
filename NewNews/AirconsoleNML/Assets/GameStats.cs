﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;

public class GameStats : MonoBehaviour
{
    public GameObject teamPrefab;
    private GameObject teamManager;
    public List<Team> teams = new List<Team>();
    [SerializeField] private string[] teamNames = {"De Telegraaf", "De Gelderlander", "Algemeen Dagblad",
    "De Volkskrant", "Trouw", "Tubantia", "Metro", "De Stentor"};
    [SerializeField]
    private string[] topicList = {"Sport", "Politiek", "Actueel Nieuws",
    "Klimaat", "Showbusiness", "Misdaad"};
    private int teamCount = 0;
    private List<Tuple<string, int>> topics = new List<Tuple<string, int>>();
    private List<string> not_ready_teams = new List<string>();
    public string[] chosenTopics;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        teamManager = GameObject.FindGameObjectWithTag("Teams");
        initializeTopicsList();
    }

    public List<Team> getTeams()
    {
        return teams;
    }

    public void setChosenTopics(string[] topics)
    {
        chosenTopics = topics;
    }

    public string[] getChosenTopics()
    {
        return chosenTopics;
    }

    public string[] getTopics()
    {
        return topicList;
    }

    private void initializeTopicsList()
    {
        foreach (string topic in topicList)
        {
            topics.Add(new Tuple<string, int>(topic, 0));
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        GameObject.FindGameObjectWithTag("Teams").GetComponent<Teams>().instantiateTeams(teams);
    }

    // Update is called once per frame
    void Update()
    {
        updateRanking();
    }

    public int addTeam(int device_id)
    {
        //var teamObject = Instantiate(teamPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //teamObject.transform.SetParent(gameObject.transform);
        //teamObject.transform.localScale = new Vector3(1f, 1f, 1f);
        //teamObject.GetComponent<TeamUI>().setTeamNumber(teamCount);
        //teamObject.GetComponent<TeamUI>().setName(teamNames[teamCount]);
        //teamObject.GetComponent<TeamUI>().setTeamReady(true);
        //int playerNumber = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
        //print("Adding team: " + teamCount + ", with device id: " + device_id +
        //    ", and player number: " + playerNumber);

        //int teamNumber = teamCount;
        //int teamNumnber = device_id;
        //int teamNumnber = player_id;
        Team t = new Team(teamNames[teamCount], device_id);
        //GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().AssignTeamNames(device_id, teamNames[teamCount]);
        teams.Add(t);
        teamManager.GetComponent<Teams>().instantiateTeam(t);
        teamCount += 1;
        return device_id;
    }



    public void updateTeams()
    {
        foreach (Team t in teams)
        {
            teamManager.GetComponent<Teams>().updateTeam(t);
        }
    }

    public Team getTeam(int teamNumber)
    {
        foreach (Team t in teams)
        {
            if (t.getTeamDeviceID() == teamNumber) return t;
        }
        return null;
    }

    public int amountOfTeams()
    {
        int i = 0;
        foreach (Team t in teams)
        {
            i += 1;
        }
        return i;
    }

    public bool allTeamsReady()
    {
        if (amountOfTeams() < 1) return false;
        else return amountOfTeams() == amountOfReadyTeams();
    }

    public bool halfTeamsReady()
    {
        if (amountOfTeams() < 1) return false;
        else return (int)Math.Ceiling((double)amountOfTeams() / 2) == amountOfReadyTeams();
    }

    private class teamSort : IComparer<Team>
    {
        int IComparer<Team>.Compare(Team _objA, Team _objB)
        {
            int t1 = _objA.getScore();
            int t2 = _objB.getScore();
            return t1.CompareTo(t2);
        }
    }
    private static int SortByScore(Team o1, Team o2)
    {
        return o2.getScore().CompareTo(o1.getScore());
    }

    public void updateRanking()
    {
        teamManager = GameObject.FindGameObjectWithTag("Teams");
        teams.Sort(SortByScore);
        int i = 0;
        foreach (Team t in teams)
        {
            t.setTeamRank(i);

            teamManager.GetComponent<Teams>().updateTeam(t);
            i += 1;
        }
    }

    public int amountOfReadyTeams()
    {
        int i = 0;
        foreach (Team team in teams)
        {
            if (team.getTeamReady() == true) i += 1;
        }
        return i;
    }

    public List<string> NotReadyTeams()
    {
        foreach (Team team in teams)
        {
            if (team.getTeamReady() == false) not_ready_teams.Add(team.getTeamDeviceID().ToString());
        }
        return not_ready_teams;
    }

    public void setAllTeamsNotReady()
    {
        foreach (Team team in teams)
        {
            team.setTeamReady(false);
        }
    }

    // MAKE THIS WORK AI COMPONENT STYLE
    public string getRealFakeSentence()
    {
        return "Example Sentence";
    }

    public string getSourceSentence()
    {
        return "Example Sentence";
    }
}


