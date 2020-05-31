using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    private string teamName;
    private int teamDeviceID = 0;
    private int threeVotes = 6; //should be 3 once the double onMessage is fixed
    private int teamRank = 0;
    private int teamScore = 0;
    private bool teamReady = false;
    private bool boolAnswer;
    private string stringAnswer;
    private List<int> matches = new List<int>();
    private bool[] votes = new bool[] { false, false, false, false, false, false };
    //0 = Sport, 1 =  Politiek, 2 =  Actueel Nieuws, 3 = Klimaat, 4 = Showbusiness, 5 = Misdaad
    //A = Sport, B =  Politiek, C =  Actueel Nieuws, D = Klimaat, E = Showbusiness, F = Misdaad

    public void voteForTopic(int top)
    {
        votes[top] = true;
    }

    public bool hasChosenThreeTopics()
    {
        int i = 0;
        foreach (bool b in votes)
        {
            if (b) i++;
        }
        return i >= 3;
    }

    public bool[] getVotes()
    {
        return votes;
    }


    public int getThreeVotes()
    {
        return threeVotes;
    }

    public void decrementThreeVotes()
    {
        threeVotes -= 1;
    }

    public void setBoolAnswer(bool answer)
    {
        boolAnswer = answer;
    }

    public bool getBoolAnswer()
    {
        return boolAnswer;
    }

    public string getStringAnswer()
    {
        return stringAnswer;
    }

    public void setStringAnswer(string answer)
    {
        stringAnswer = answer;
    }

    public Team(string name)
    {
        teamName = name;
    }

    public Team(string name, int number)
    {
        teamName = name;
        teamDeviceID = number;
    }

    public void setTeamRank(int rank)
    {
        teamRank = rank;
    }

    public void setTeamReady(bool ready)
    {
        teamReady = ready;
    }

    public void setName(string name)
    {
        teamName = name;
    }

    public void setScore(int score)
    {
        teamScore = score;
    }

    public void setTeamDeviceID(int nr)
    {
        teamDeviceID = nr;
    }

    public void addScore(int score)
    {
        setScore(teamScore + score);
    }

    public int getScore()
    {
        return teamScore;
    }

    public int getTeamDeviceID()
    {
        return teamDeviceID;
    }

    public string getTeamName()
    {
        return teamName;
    }

    public bool getTeamReady()
    {
        return teamReady;
    }

    public int getTeamRank()
    {
        return teamRank;
    }

    public bool hasMatchedAll()
    {
        return matches.Count == 4;
    }

    public void voteMatch(int v)
    {
        if (!matches.Contains(v))
        {
            matches.Add(v);
            Debug.Log("the list: " + matches);
        }
    }

    public List<int> getMatches()
    {
        return matches;
    }

    public void clearMatches()
    {
        matches.Clear();
    }
}
