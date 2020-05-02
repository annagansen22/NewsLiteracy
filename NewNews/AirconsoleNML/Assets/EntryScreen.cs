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
    //public int ready_count = 0;
    //public List<int> ready_devices;// = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count);
    private Progressbar progressbar;

    private void Awake()
    {

        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
        //ready_devices = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count); ;
        progressbar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
    }

    private void Start()
    {
        GameObject gameLogic = GameObject.FindGameObjectWithTag("GameLogic");
        //gameLogic.GetComponent<GameL>().testInitialization();
    }

    private void OnMessage(int device_id, JToken data)
    {
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

    private void BroadcastMessageToAllDevices()
    {
        AirConsole.instance.Broadcast("view-1");
    }


    // If the ready button is pressed by the teacher
    public void startGame()
    {
        //AirConsole.instance.SetActivePlayers();
        AirConsole.instance.SetCustomDeviceState(1);
        int t = 30;
        string time = FindObjectOfType<TMP_InputField>().text;
        print(time);
        if (time != "") t = int.Parse(time);
        print("Timer set to " + t + " minutes");
        print("Start date is: " + System.DateTime.Now);
        DateTime maxTime = System.DateTime.Now.AddMinutes(t);
        print("End date is: " + maxTime);
        BroadcastMessageToAllDevices();
        //OnDestroy();
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().setMaxTime(maxTime);
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().nextScene(SceneManager.GetActiveScene().name);
    }
}

