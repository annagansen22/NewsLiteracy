using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AIComponent : MonoBehaviour
{
    public List<string> minigameScenes;
    public string entryScene;
    public string feedbackScene;
    public string pickTopicScene;
    public string rankingScene;
    public string reflectionScene;
    public string informationScene;
    private int hardCodeMiniGame = 0;
    private string abc;

    private System.DateTime maxTime;
    private string lastGameScene;
    private string lastScene;
    public void setMaxTime(System.DateTime date)
    {
        maxTime = date;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignTeamNames(int device_id, string teamname)
    {
        JObject TeamNameData = new JObject();
        //if (TeamNameData[device_id.ToString()] == null)
        //{
        //    TeamNameData.Add(device_id.ToString(), teamname);
        //}
        //else
        //{
        //    TeamNameData[device_id.ToString()] = teamname;
        //}
        //Debug.Log("AssignTeamName for device " + device_id + " returning new TeamNameData: " + TeamNameData);
        //AirConsole.instance.SetCustomDeviceState(TeamNameData);
        if(TeamNameData["teamnames"] == null) 
        {
            TeamNameData.Add("teamnames", teamname);
        }
        else
        {
            TeamNameData["teamnames"] = teamname;
        }
        AirConsole.instance.Message(device_id,TeamNameData);
    }



    public void personalizedMessage()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        print("scene name" + currentScene);
        for (int i = 0; i < AirConsole.instance.GetControllerDeviceIds().Count; i++)
        {
            if (currentScene == feedbackScene && lastScene == "RealFakeScene")
            {
                // fetch
                // message
                print("FEEDBACK FOR REALFAKE GAME!!!");
            }
            else if (currentScene == feedbackScene && lastScene == "SourceScene")
            {
                // fetch
                // message
                print("FEEDBACK FOR SOURCE GAME!!!");
            }
            //can add more here... check public/private variables at the top of this script
        }
    }

    public string getLastGameScene()
    {
        return lastGameScene;
    }


    public void displayTeamName(int device_id, string data)
    {
        AirConsole.instance.Message(device_id, data);
    }

    public string timeLeft()
    {
        return (System.DateTime.Now - maxTime).ToString();
    }

    public void nextScene(string currentScene)
    {
        //If there is time left
        if (System.DateTime.Now.CompareTo(maxTime) <= 0)
        {


            // CALCULATE NEXT SCENE USING ADVANCED AI!!!!

            string nextScene = "";
            // After minigame do feedback
            foreach (string scene in minigameScenes)
            {
                if (scene == currentScene)
                {
                    nextScene = reflectionScene;
                    lastGameScene = scene;
                }
                if (reflectionScene == currentScene)
                {
                    nextScene = feedbackScene;
                }
                if (feedbackScene == currentScene)
                {
                    nextScene = informationScene;
                }
            }
            // OTHERWISE!!!
            // After entryscene do picktopics
            if (currentScene == entryScene) nextScene = pickTopicScene;
            //else if (nextScene == "") nextScene = minigameScenes[Random.Range(0, minigameScenes.Count)];
            else if (nextScene == "")
            {
                switch (hardCodeMiniGame)
                {
                    case 0:
                        nextScene = "RealFakeScene";
                        break;
                    case 1:
                        nextScene = "SourceScene";
                        break;
                    case 2:
                        nextScene = "HeadLinesScene";
                        break;
                    case 3:
                        nextScene = "RealFakeScene";
                        break;
                    /////////////////////////////////////////////
                    default:
                        nextScene = "RealFakeScene";
                        break;
                }
                hardCodeMiniGame++;
                if (hardCodeMiniGame >= 3) hardCodeMiniGame = 0;
            }
            print(Random.Range(0, minigameScenes.Count));
            loadScene(currentScene, nextScene);
        }
        else
        {
            //End game
            print("GAME SHOULD END!!!");
            loadScene(currentScene, rankingScene);
        }
    }

    private void loadScene(string currentScene, string nextScene)
    {
        lastScene = currentScene;
        print("Switching from '" + currentScene + "' to '" + nextScene + "'");
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setAllTeamsNotReady();
        SceneManager.LoadScene(nextScene);
    }

    public void SetView(string viewName)
    {
        AirConsole.instance.SetCustomDeviceState(viewName);
    }

}
