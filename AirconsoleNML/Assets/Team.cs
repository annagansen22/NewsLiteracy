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
}
