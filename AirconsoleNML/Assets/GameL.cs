using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class GameL : MonoBehaviour
{
    private int followers;
    private int i;
    private int j;
    public List<int> a = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count);
    public List<int> b = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count);
    public List<int> c = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count);
    public List<int> d = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count); 
    public List<int> e = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count);
    public List<int> f = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count);
    public List<int> ready = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count);




private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }

    private void BroadcastMessageToAllDevices()
    {
        AirConsole.instance.Broadcast("view-2");
    }


    private void OnMessage(int device_id, JToken data)
    {

        Debug.Log("message from: " + device_id + ", data: " + data);
        for (int j = 0; j < AirConsole.instance.GetControllerDeviceIds().Count; j++)
        {
            if (data["element"] != null & data["element"].ToString() == "view-1-section-1-element-0" && device_id == AirConsole.instance.GetControllerDeviceIds()[j])
            {
                if (data["data"]["1"].ToString().Equals("A"))
                {
                    Debug.Log("A was pressed");
                    
                    if (a[j] != 1)
                    {
                        
                        a[j] = 1;
                    }
                }
            }

            if (data["element"] != null & data["element"].ToString() == "view-1-section-2-element-0" && device_id == AirConsole.instance.GetControllerDeviceIds()[j])
            {
                if (data["data"]["1"].ToString().Equals("B") && (a[j] + b[j] + c[j] + d[j] + e[j] + f[j]) < 3)
                {
                    Debug.Log("B was pressed");
                    if (b[j] != 1)
                    {
                        
                        b[j] = 1;
                    }
                }
            }

            if (data["element"] != null & data["element"].ToString() == "view-1-section-3-element-0" && device_id == AirConsole.instance.GetControllerDeviceIds()[j])
            {
                if (data["data"]["1"].ToString().Equals("C") && (a[j] + b[j] + c[j] + d[j] + e[j] + f[j]) < 3)
                {
                    Debug.Log("C was pressed");
                    if (c[j] != 1)
                    {
                      
                        c[j] = 1;
                    }

                }
            }

            if (data["element"] != null & data["element"].ToString() == "view-1-section-1-element-1" && device_id == AirConsole.instance.GetControllerDeviceIds()[j])
            {
                if (data["data"]["1"].ToString().Equals("D") && (a[j] + b[j] + c[j] + d[j] + e[j] + f[j]) < 3)
                {
                    Debug.Log("D was pressed");
                    if (d[j] != 1)
                    {
                        d[j] = 1;
                    }
                }
            }

            if (data["element"] != null & data["element"].ToString() == "view-1-section-2-element-1" && device_id == AirConsole.instance.GetControllerDeviceIds()[j])
            {
                if (data["data"]["1"].ToString().Equals("E") && (a[j] + b[j] + c[j] + d[j] + e[j] + f[j]) < 3)
                {
                    Debug.Log("E was pressed");
                    if (e[j] != 1)
                    {
                        e[j] = 1;
                    }

                }
            }

            if (data["element"] != null & data["element"].ToString() == "view-1-section-3-element-1" && device_id == AirConsole.instance.GetControllerDeviceIds()[j])
            {
                if (data["data"]["1"].ToString().Equals("F") && (a[j] + b[j] + c[j] + d[j] + e[j] + f[j]) < 3)
                {
                    Debug.Log("F was pressed");
                    if (f[j] != 1)
                    {
                        f[j] = 1;
                    }
                }
            }
            if((a[j] + b[j] + c[j] + d[j] + e[j] + f[j]) == 3 && !ready.Contains(device_id) && device_id == AirConsole.instance.GetControllerDeviceIds()[j])
            {
                ready.Add(device_id);
                Debug.Log("added: " + device_id);
                if (ready.Count == AirConsole.instance.GetControllerDeviceIds().Count)
                {
                    SceneManager.LoadScene("RealFakeScene");
                    BroadcastMessageToAllDevices();
                }
            }

        }


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
        for (int k = 0; k < AirConsole.instance.GetControllerDeviceIds().Count; k++)
        {
            a.Add(0);
            b.Add(0);
            c.Add(0);
            d.Add(0);
            e.Add(0);
            f.Add(0);
        }
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
        else if (Input.GetKeyDown(KeyCode.P))
        {
            print("Typed P -> Going to picktopics scene");
            SceneManager.LoadScene("PickTopicsScene");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            print("Typed F -> Going to picktopics scene");
            SceneManager.LoadScene("RealFakeScene");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            print("Typed T -> Printing topics");
            string[] t = gameObject.GetComponent<GameStats>().getChosenTopics();
            foreach (string x in t)
            {
                print("TOPIC: " + x);
            }
        }

    }
}

