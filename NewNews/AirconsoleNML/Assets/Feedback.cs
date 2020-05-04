using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;

public class Feedback : MonoBehaviour
{
    private bool onlyDoOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        // Add onMessage
        AirConsole.instance.onMessage += OnMessage;

        // Set Controller View
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().SetView("view-3");

        // Personalized Message
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().personalizedMessage();

        //If this is uncommented, the scene works on a 5 sec timer instead of when all teams pressed okay
        //StartCoroutine(WaitForSecondsThenSwitchScene(5));
    }
    private void OnMessage(int device_id, JToken data)
    {
        print("testing for duplicates: " + device_id);
        //Sometimes data is null and airconsole has a chance to not be ready yet
        if (data != null && AirConsole.instance.IsAirConsoleUnityPluginReady())
        {
            //print(data["element"].ToString());
            //Element should not be empty
            if (data["element"] != null && data["element"].ToString() == "view-3-section-0-element-0")
            {
                //Loop over all connected devices
                for (int i = 0; i < AirConsole.instance.GetControllerDeviceIds().Count; i++)
                {
                    print(data["data"].ToString());
                    //If data says ready
                    if (data["data"]["1"].ToString().Equals("OK") && device_id == AirConsole.instance.GetControllerDeviceIds()[i])
                    {
                        print("Team " + GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).getTeamName() + " pressed ready (dev id: " + device_id + ")");
                        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeam(device_id).setTeamReady(true);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().allTeamsReady() && onlyDoOnce)
        {
            // Wait for X seconds and go to next screen
            onlyDoOnce = false;
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().nextScene(SceneManager.GetActiveScene().name);
        }
    }

    public IEnumerator WaitForSecondsThenSwitchScene(int sec)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(sec);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().nextScene(SceneManager.GetActiveScene().name);
    }
}
