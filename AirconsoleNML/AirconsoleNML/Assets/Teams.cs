using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;

public class Teams : MonoBehaviour
{
    public GameObject teamPrefab;
    List<GameObject> teams = new List<GameObject>();

    //Instantiates all Team UI Objects
    public void instantiateTeams(List<Team> teamList)
    {
        foreach (Team t in teamList)
        {
            instantiateTeam(t);
        }
    }

    public void instantiateTeam(Team t)
    {
        var teamObject = Instantiate(teamPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        teamObject.transform.SetParent(gameObject.transform);
        teamObject.transform.localScale = new Vector3(1f, 1f, 1f);
        teamObject.GetComponent<TeamUI>().setTeamName(t.getTeamName());
        teams.Add(teamObject);
        updateTeam(t);
    }

    //Updates all Team UI Objects
    public void updateTeam(Team t)
    {
        foreach (GameObject team in teams)
        {
            if (team.GetComponent<TeamUI>().getTeamName() == t.getTeamName())
            {
                team.GetComponent<TeamUI>().updateUI(t);

            }
        }
    }

}


