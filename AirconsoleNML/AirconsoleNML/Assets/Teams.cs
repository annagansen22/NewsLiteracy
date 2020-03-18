using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Teams : MonoBehaviour
{
    public GameObject teamPrefab;
    ArrayList teams = new ArrayList();
    string[] teamNames = {"De Telegraaf", "De Gelderlander", "Algemeen Dagblad",
    "De Volkskrant", "Trouw", "Tubantia", "Metro", "De Stentor"};
    int teamCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;
        print(children);
        for (int i = 0; i < children; ++i)
        {
            print("For loop: " + transform.GetChild(i));
            teams.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addTeam(int device_id)
    {     
        var teamObject = Instantiate(teamPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        teamObject.transform.SetParent(gameObject.transform);
        teamObject.transform.localScale = new Vector3(1f, 1f, 1f);
        int playerNumber = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);

        //teamObject.GetComponent<TeamUI>().setTeamNumber(playerNumber);
        //teamObject.GetComponent<TeamUI>().setName(teamNames[playerNumber]);
        teamObject.GetComponent<TeamUI>().setTeamNumber(teamCount);
        teamObject.GetComponent<TeamUI>().setName(teamNames[teamCount]);
        print("Adding team: " + teamCount + ", with device id: " + device_id +
            ", and player number: " + playerNumber);
        teamCount += 1;
        teams.Add(teamObject);
    }

    public GameObject getTeam(int teamNumber)
    {
        foreach (GameObject team in teams){
            if (team.GetComponent<TeamUI>().getTeamNumber() == teamNumber) return team;
        }
        return null;
    }

    public int amountOfTeams()
    {
        int i = 0;
        foreach (GameObject team in teams)
        {
            i += 1;
        }
        return i;
    }




}
