using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class EntryScreen : MonoBehaviour
{
    public int ready_count = 0;
    public List<int> ready_devices = new List<int>(AirConsole.instance.GetControllerDeviceIds().Count);
    private Progressbar progressbar;
    // Start is called before the first frame update
    void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
        progressbar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
    }

    private void OnMessage(int device_id, JToken data)
    {

        if (data["element"] != null & data["element"].ToString() == "view-0-section-0-element-0")
        {
            for (int i = 0; i < AirConsole.instance.GetControllerDeviceIds().Count; i++)
            {

                if (data["data"]["1"].ToString().Equals("Ready") && !ready_devices.Contains(device_id) && device_id == AirConsole.instance.GetControllerDeviceIds()[i])
                {
                    ready_count += 1;
                    ready_devices.Add(device_id);
                    if (ready_count == AirConsole.instance.GetControllerDeviceIds().Count)
                    {

                        startGame();
                    }
                }
            }
        }
    }


    private void OnConnect(int device_id)
    {
        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
        {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
            {

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

    private void BroadcastMessageToAllDevices()
    {
        AirConsole.instance.Broadcast("view-1");
    }

    public void startGame()
    {
        GameObject gameLogic = GameObject.FindGameObjectWithTag("GameLogic");
        gameLogic.GetComponent<GameStats>().setAllTeamsNotReady();
        AirConsole.instance.SetCustomDeviceState(1);
        string sceneToLoad = "";
        sceneToLoad = "SampleScene";
        sceneToLoad = "PickTopicsScene";
        print("Loading " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
        BroadcastMessageToAllDevices();
    }


    private void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // If all teams are ready
        //    if (progressbar.allTeamsReady())
        //    {
        //        startGame();
        //    }
    }

    // If the ready button is pressed


}
