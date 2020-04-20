using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIComponent : MonoBehaviour
{
    public List<string> minigameScenes;
    public string entryScene;
    public string feedbackScene;
    public string pickTopicScene;

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
        // CALCULATE NEXT SCENE USING ADVANCED AI!!!!
        string nextScene;
        if (currentScene == entryScene) nextScene = pickTopicScene;
        else nextScene = minigameScenes[0];

        print("Switching from '" + currentScene + "' to '" + nextScene + "'");
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setAllTeamsNotReady();
        SceneManager.LoadScene(nextScene);

    }
}
