using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System;

public class AIComponent : MonoBehaviour
{
    public List<string> minigameScenes;
    public string entryScene;
    public string feedbackScene;
    public string pickTopicScene;
    public string rankingScene;
    public string reflectionScene;
    public string informationScene;
    public string chosenTopicScene;
    private int prevScene = -1;
    private int[] gameCount = new int[] { 0, 0, 0, 0 };
    private string abc;

    private System.DateTime maxTime;
    private string lastGameScene;
    private string lastScene;

    private float reflectionLevel;
    private float checkingLevel;

    public void addAIData(float refl, float check, bool win)
    {
        if (!win)
        {
            refl *= -1;
            check *= -1;
        }
        int amountOfTeams = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTeams().Count;
        reflectionLevel += refl / amountOfTeams;
        checkingLevel += check / amountOfTeams;

        //after that assume they learnt anyway to promote diversity
        reflectionLevel += refl / 2;
        checkingLevel += check / 2;
    }

    public void setMaxTime(System.DateTime date)
    {
        maxTime = date;
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
            if (currentScene == pickTopicScene) nextScene = chosenTopicScene;
            //else if (nextScene == "") nextScene = minigameScenes[Random.Range(0, minigameScenes.Count)];
            else if (nextScene == "")
            {
                // AI COMPONENT HARD AT WORK HERE
                // 0 = realfake, 1 = sourcegame, 2 = headline, 3 = matching
                int chosenMini = GetNextMiniGame();
                prevScene = chosenMini;
                int curGameCount = gameCount[chosenMini];
                gameCount[chosenMini] = curGameCount + 1; ;
                switch (chosenMini)
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
            }
            loadScene(currentScene, nextScene);
        }
        else
        {
            //End game
            loadScene(currentScene, rankingScene);
        }
    }

    private int GetNextMiniGame()
    {
        //REMOVE THIS!!!
        if (prevScene == -1) return 2;

        print("gameCount: ");
        foreach (var x in gameCount) Debug.Log(x.ToString());
        print("reflectionLev: " + reflectionLevel + ", checkingLev: " + checkingLevel);
        //Select randomly be default
        int nextmini = UnityEngine.Random.Range(0, 4);
        // 0 = realfake, 1 = sourcegame, 2 = headline, 3 = matching
        if (reflectionLevel > checkingLevel)
        {
            //real fake or sourcegame 
            if (prevScene == 0) nextmini = 1;
            else if (prevScene == 1) nextmini = 0;
            else
            {
                if (gameCount[0] > gameCount[1]) nextmini = 1;
                else nextmini = 0;
            }
        }
        else if (checkingLevel > reflectionLevel)
        {
            //headline or matchinh
            if (prevScene == 2) nextmini = 3;
            else if (prevScene == 3) nextmini = 2;
            else
            {
                if (gameCount[2] > gameCount[3]) nextmini = 3;
                else nextmini = 2;
            }
        }
        //Else just do something random
        print("next minigame is :" + nextmini);
        return nextmini;
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
