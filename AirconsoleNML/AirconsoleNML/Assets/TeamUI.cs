using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamUI : MonoBehaviour
{
    [SerializeField] private GameObject nameObject;
    //[SerializeField] private TextMeshProUGUI teamObj;
    [SerializeField] private string teamName;
    [SerializeField] private int teamNumber;
    [SerializeField] private int teamScore = 0;

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

    private void updateText()
    {
        string teamText = "<b> " + teamName + " </b> \n Volgers: " + teamScore;
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = teamText;
    }

    public void setTeamNumber(int nr)
    {
        teamNumber = nr;
    }

    public int getTeamNumber()
    {
        return teamNumber;
    }

    public void setTeamScore(int nr)
    {
        teamScore = nr;
    }

    public string getTeamName()
    {
        return teamName;
    }
}
