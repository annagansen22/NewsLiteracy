using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;
using TMPro;

public class InformationScript : MonoBehaviour
{
    private bool onlyDoOnce = true;
    private InformationData data;
    private GameObject gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        // Add onMessage
        AirConsole.instance.onMessage += OnMessage;

        // Initialize some objects
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic");

        // Get information data
        List<InformationData> infoList = getData();
        print("Amount info blocks left for " + GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().getLastGameScene() + ": " + infoList.Count);
        gameLogic.GetComponent<GamesData>().setInformationData(infoList);

        // Set reflection question on the screen
        GameObject.FindGameObjectWithTag("InformationText").GetComponent<TextMeshProUGUI>().text = "<b> Tip:  </b>\n" + data.getInformation();

        // Set Controller View
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().SetView("view-6");

        //If this is uncommented, the scene works on a 5 sec timer instead of when all teams pressed okay
        StartCoroutine(WaitForSecondsThenSwitchScene(10));
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

    private List<InformationData> getData()
    {
        // Get the last scene: minigame
        string lastScene = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().getLastGameScene();

        // Get the information data from data object
        List <InformationData> dataList = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GamesData>().getInformationData();

        List<InformationData> shuffledData = dataList.OrderBy(x => UnityEngine.Random.value).ToList();

        foreach (InformationData d in shuffledData)
        {
            string game = d.getGame();
            print("Game: " + game);
            if (game == lastScene)
            {
                data = d;
                shuffledData.Remove(d);
                return shuffledData;
            }
        }
        return shuffledData;
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
