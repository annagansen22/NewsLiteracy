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

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        //AirConsole.instance.onMessage += OnMessage;
        //AirConsole.instance.onConnect += OnConnect;
        //AirConsole.instance.onDisconnect += OnDisconnect;
    }

    private void OnMessage(int device_id, JToken data)
    { 
    }

    private void OnConnect(int device_id)
    {
    }

    private void OnDisconnect(int device_id)
    {
    }

    void StartGame()
    {
        Debug.Log("game has started!");
        //teams = GameObject.FindGameObjectWithTag("Teams");
    }

    private void OnDestroy()
    {
        //if (AirConsole.instance != null)
        //{
        //    AirConsole.instance.onMessage -= OnMessage;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        followers = 1000;
    }

    public void testInitialization()
    {
        GameStats gs = gameObject.GetComponent<GameStats>();
        for (int i = 0; i<=7; i++)
        {
            int teamNum = gs.addTeam(0);
            gs.getTeam(teamNum).setScore(followers);
            followers -= Random.Range(30, 125);
            gs.updateRanking();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        GameStats gs = gameObject.GetComponent<GameStats>();
        // NUMBERS
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    print("Typed 1 -> Randomizing A Teams Followers");
        //    int r = Random.Range(0, gs.amountOfTeams());
        //    int score = Random.Range(0, 1000);
        //    Team selectedTeam = gs.teams[r];
        //    selectedTeam.setScore(score);
        //    GameObject.FindGameObjectWithTag("Teams").GetComponent<Teams>().updateTeam(selectedTeam);
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    print("Typed 2 -> Adding A Team");
        //    int teamNum = gs.addTeam(0);
        //    gs.getTeam(teamNum).setScore(followers);
        //    followers -= Random.Range(30, 125);
        //    gs.updateRanking();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    print("Typed 3 -> Updating Ranking");
        //    gs.updateRanking();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    print("Typed 4 -> Setting Random Team To Ready");
        //    int r = Random.Range(0, gs.amountOfTeams());
        //    Team selectedTeam = gs.teams[r];
        //    selectedTeam.setTeamReady(true);
        //}
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            print("Typed 5 -> Setting All Teams To Ready");
            for (int i = gs.amountOfTeams()-1; i >= 0; i--)
            {
                Team selectedTeam = gs.teams[i];
                selectedTeam.setTeamReady(true);
            }
        }
        // LETTERS
        else if (Input.GetKeyDown(KeyCode.P))
        {
            print("Typed P -> Going to picktopics scene");
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setAllTeamsNotReady();
            SceneManager.LoadScene("PickTopicsScene");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            print("Typed F -> Going to realfake scene");
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setAllTeamsNotReady();
            SceneManager.LoadScene("RealFakeScene");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            print("Typed S -> Going to source scene");
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setAllTeamsNotReady();
            SceneManager.LoadScene("SourceScene");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            print("Typed H -> Going Headlines Scene");
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setAllTeamsNotReady();
            SceneManager.LoadScene("HeadlinesScene");
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
        else if (Input.GetKeyDown(KeyCode.L))
        {
            print("Time left: " + GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().timeLeft());
        }

    }



}

