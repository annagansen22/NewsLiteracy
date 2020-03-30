using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class GameL : MonoBehaviour
{
    private int followers;
    private int i;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
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
        gameObject.GetComponent<GameStats>().addTeam(0);
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
    }

    // Update is called once per frame
    void Update()
    {
        GameStats gs = gameObject.GetComponent<GameStats>();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Typed 1 -> Randomizing A Teams Followers");
            int r = Random.Range(0, gs.amountOfTeams());
            int score = Random.Range(0, 1000);
            Team selectedTeam = gs.teams[r];
            selectedTeam.setScore(score);
            GameObject.FindGameObjectWithTag("Teams").GetComponent<Teams>().updateTeam(selectedTeam);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Typed 2 -> Adding A Team");
            int teamNum = gs.addTeam(0);
            gs.getTeam(teamNum).setScore(followers);
            followers -= Random.Range(30, 125);
            gs.updateRanking();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("Typed 3 -> Updating Ranking");
            gs.updateRanking();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("Typed 4 -> Setting Random Team To Ready");
            int r = Random.Range(0, gs.amountOfTeams());
            Team selectedTeam = gs.teams[r];
            selectedTeam.setTeamReady(true);
        }
          
    }
}

