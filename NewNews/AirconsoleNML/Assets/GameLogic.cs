﻿//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using NDream.AirConsole;
//using Newtonsoft.Json.Linq;

//public class GameLogic : MonoBehaviour
//{
//    private void Awake()
//    {
//        DontDestroyOnLoad(gameObject);
//        AirConsole.instance.onMessage += OnMessage;
//        AirConsole.instance.onConnect += OnConnect;
//        AirConsole.instance.onDisconnect += OnDisconnect;
//    }

//    private void OnMessage(int device_id, JToken data)
//    {
//        Debug.Log("message from: " + device_id + ", data: " + data);
//        if (data["action"] != null)
//        {
//            if (data["action"].ToString().Equals("real"))
//            {
//                Debug.Log("real was pressed");
//            }
//            if (data["action"].ToString().Equals("fake"))
//            {
//                Debug.Log("fake was pressed");
//            }
//        }
//    }

//    private void OnConnect(int device_id)
//    {
//        addTeam(device_id);
//        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
//        {
//            if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
//            {
//                StartGame();
//            }
//        }
//    }

//    private void OnDisconnect(int device_id)
//    {
//        //int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
//        //if (active_player != -1)
//        //{
//        //    if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
//        //    {
//        //        StartGame();
//        //    }
//        //}
//    }

//    void StartGame()
//    {
//        Debug.Log("game has started!");
//    }

//    private void OnDestroy()
//    {
//        if (AirConsole.instance != null)
//        {
//            AirConsole.instance.onMessage -= OnMessage;
//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.A))
//        {
//            print("A is pressed");
            
//        }
//    }

//    private void addTeam(int device_id)
//    {
//        GameObject.FindGameObjectWithTag("Teams").GetComponent<Teams>().addTeam(device_id);
//    }
//}
