using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamUI : MonoBehaviour
{
    private Image im;
    private GameObject nameObject;
    [SerializeField] private string teamName;
    [SerializeField] private int teamNumber = 0;
    [SerializeField] private int teamRank = 0;
    [SerializeField] private int teamScore = 0;
    [SerializeField] private bool teamReady = false;

    public void Start()
    {
        im = gameObject.GetComponent<Image>();
    }

    public void setTeamRank(int rank)
    {
        teamRank = rank;
        updateText();
    }

    public bool getTeamReady()
    {
        return teamReady;
    }

    public void setTeamReady(bool ready)
    {
        if (im != null)
        {
            if (ready) im.color = new Color(0.8f, 0.8f, 0.8f);
            else im.color = new Color(1f, 1f, 1f);
        }
        teamReady = ready;
    }

    public void setName(string name)
    {
        teamName = name;
        updateText();
    }

    public void setScore(int score)
    {
        teamScore = score;
        updateText();
    }

    public void addScore(int score)
    {
        setScore(teamScore + score);
    }

    public int getScore()
    {
        return teamScore;
    }

    private void updateText()
    {
        string teamText = "<b> " + teamName + " </b> \n Volgers: " + teamScore;
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = teamText;
        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (teamRank+1).ToString();
    }

    public void setTeamNumber(int nr)
    {
        teamNumber = nr;
    }

    public int getTeamNumber()
    {
        return teamNumber;
    }

    public string getTeamName()
    {
        return teamName;
    }
}
