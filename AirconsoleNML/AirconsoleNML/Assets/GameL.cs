using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class GameL : MonoBehaviour
{
    private GameObject teams;
    private int followers;
    private int i;

    private void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
        teams = GameObject.FindGameObjectWithTag("Teams");
    }

    private void OnMessage(int device_id, JToken data)
    {
        Debug.Log("message from: " + device_id + ", data: " + data);
        if (data["action"] != null)
        {
            if (data["action"].ToString().Equals("real"))
            {
                Debug.Log("real was pressed");
                Camera.main.backgroundColor = Color.green;
            }
            if (data["action"].ToString().Equals("fake"))
            {
                Debug.Log("fake was pressed");
                Camera.main.backgroundColor = Color.red;
            }
        }
    }

    private void OnConnect(int device_id)
    {
        print("OnConnect");
        GameObject.FindGameObjectWithTag("Teams").GetComponent<Teams>().addTeam(device_id);
        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
        {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 8)
            {
                StartGame();
            }
        }
    }

    private void OnDisconnect(int device_id)
    {
        //int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
        //if (active_player != -1)
        //{
        //    if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
        //    {
        //        StartGame();
        //    }
        //}
    }

    void StartGame()
    {
        Debug.Log("game has started!");
        //teams = GameObject.FindGameObjectWithTag("Teams");
    }

    private void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        followers = 1000;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        teams = GameObject.FindGameObjectWithTag("Teams");
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            print("Typed 0");
            int score = (int)Random.Range(0, 100);
            teams.GetComponent<Teams>().getTeam(0).GetComponent<TeamUI>().setScore(score);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Typed 1");
            int score = (int)Random.Range(0, 100);
            teams.GetComponent<Teams>().getTeam(1).GetComponent<TeamUI>().setScore(score);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Typed 2");
            teams.GetComponent<Teams>().addTeam(i);
            teams.GetComponent<Teams>().getTeam(i).GetComponent<TeamUI>().setScore(followers);
            i += 1;
            followers -= (int)Random.Range(30, 125);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("Typed 3");
            teams.GetComponent<Teams>().updateRanking();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("Typed 4");
            int r = Random.Range(0, teams.GetComponent<Teams>().amountOfTeams());
            teams.GetComponent<Teams>().getTeam(r).GetComponent<TeamUI>().setTeamReady(true);
        }
    }
}

