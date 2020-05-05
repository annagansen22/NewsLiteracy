using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityScript.Steps;

public class AIComponent : MonoBehaviour
{
    public List<string> minigameScenes;
    public string entryScene;
    public string feedbackScene;
    public string pickTopicScene;
    public string rankingScene;


    private System.DateTime maxTime;
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

    public void personalizedMessage()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        print("scene name" + currentScene);
        for ( int i = 0; i < AirConsole.instance.GetControllerDeviceIds().Count; i++)
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
                    nextScene = feedbackScene;
                }
            }
            // OTHERWISE!!!
            // After entryscene do picktopics
            if (currentScene == entryScene) nextScene = pickTopicScene;
            else if (nextScene == "") nextScene = minigameScenes[Random.Range(0, minigameScenes.Count)];
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
        //I don't need to replace the entire game state, I can just set the view property
        AirConsole.instance.SetCustomDeviceState(viewName);
        //the controller listens for the onCustomDeviceStateChanged event. See the  controller-gamestates.html file for how this is handled there. 
    }

}
