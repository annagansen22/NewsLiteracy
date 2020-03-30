using System.Collections;
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
    "Klimaat", "Beroemdheden", "Misdaad"};
    private int teamCount = 0;
    private List<Tuple<string, int>> topics = new List<Tuple<string, int>>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        teamManager = GameObject.FindGameObjectWithTag("Teams");
        initializeTopicsList();
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
        print("Current Level: " + level);
    }

    // Start is called before the first frame update
    void Start()
    {

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

        int teamNumber = teamCount;
        //int teamNumnber = device_id;
        Team t = new Team(teamNames[teamCount], teamCount);
        teams.Add(t);
        teamManager.GetComponent<Teams>().instantiateTeam(t);
        teamCount += 1;
        return teamNumber;
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
            if (t.getTeamNumber() == teamNumber) return t;
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

    public void setAllTeamsNotReady()
    {
        foreach (Team team in teams)
        {
            team.setTeamReady(false);
        }
    }
}


