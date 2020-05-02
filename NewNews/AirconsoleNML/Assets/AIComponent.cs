using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIComponent : MonoBehaviour
{
    public List<string> minigameScenes;
    public string entryScene;
    public string feedbackScene;
    public string pickTopicScene;
    private System.DateTime maxTime;

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
        }
    }

    private void loadScene(string currentScene, string nextScene)
    {
        print("Switching from '" + currentScene + "' to '" + nextScene + "'");
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setAllTeamsNotReady();
        SceneManager.LoadScene(nextScene);
    }
}
