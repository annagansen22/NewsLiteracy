using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;


public class EntryScreen : MonoBehaviour
{

    private void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }


    private void OnMessage(int device_id, JToken data)
    {
        print("testing for duplicates: " + device_id);
        //Sometimes data is null and airconsole has a chance to not be ready yet
        if (data != null && AirConsole.instance.IsAirConsoleUnityPluginReady())
        {
            //Element should not be empty
            if (data["element"] != null && data["element"].ToString() == "view-0-section-0-element-0")
            {
                //Loop over all connected devices
                for (int i = 0; i < AirConsole.instance.GetControllerDeviceIds().Count; i++)
                {
                    //If data says ready
                    if (data["data"]["1"].ToString().Equals("Ready") && device_id == AirConsole.instance.GetControllerDeviceIds()[i])
                    {
                        print("Team " + GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).getTeamName() + " pressed ready (dev id: " + device_id + ")");
                        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).setTeamReady(true);

                        if (GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().allTeamsReady())
                        {
                            sendteamnames();
                            StartCoroutine(WaitForSeconds(1));
                            
                        }
                    }
                }
            }
        }
    }



    private void OnConnect(int device_id)
    {
        //If the team is already present don't do anything
        if (GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id) != null)
        {
            string teamName = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).getTeamName();
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().AssignTeamNames(device_id, teamName);
            return;
        }
        //Else add a team!
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().addTeam(device_id);
    }

    private void OnDisconnect(int device_id)
    {
    }

    private void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }

    private void sendteamnames()
    {
        foreach (var device_id in AirConsole.instance.GetControllerDeviceIds())
        {
            print("hi");
            string teamName = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).getTeamName();
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().AssignTeamNames(device_id, teamName);
        }
    }

    // If the ready button is pressed by the teacher
    public void startGame()
    {
        //AirConsole.instance.SetActivePlayers();
        //AirConsole.instance.SetCustomDeviceState(1);
        int t = 10;
        string time = "";
        //time = FindObjectOfType<TMP_InputField>().text;
        print(time);
        if (time != "") t = int.Parse(time);
        print("Timer set to " + t + " minutes");
        print("Start date is: " + System.DateTime.Now);
        DateTime maxTime = System.DateTime.Now.AddMinutes(t);
        print("End date is: " + maxTime);
        AirConsole.instance.onMessage -= OnMessage;
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().SetView("view-1");
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().setMaxTime(maxTime);
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().nextScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator WaitForSeconds(int sec)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(sec);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        startGame();

    }
}

