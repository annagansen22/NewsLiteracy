using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamUI : MonoBehaviour
{
    private Image im;
    private GameObject nameObject;
    private string teamName;

    public void Start()
    {
        im = gameObject.GetComponent<Image>();
    }

    public void updateUI(Team t)
    {
        // Update Sibling Index / Rank Position
        transform.SetSiblingIndex(t.getTeamRank());

        // Update Ready Color
        if (im != null)
        {
            if (t.getTeamReady()) im.color = new Color(0.8f, 0.8f, 0.8f);
            else im.color = new Color(1f, 1f, 1f);
        }

        // Update Team Name
        teamName = t.getTeamName();

        // Update Follower Amount + Rank 
        string teamText = "<b> " + teamName + " </b> \n Volgers: " + t.getScore();
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = teamText;
        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (t.getTeamRank() + 1).ToString();
    }

    public string getTeamName()
    {
        return teamName;
    }

    public void setTeamName(string name)
    {
        teamName = name;
    }

}
