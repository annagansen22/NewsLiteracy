using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryScreen : MonoBehaviour
{

    private Progressbar progressbar;
    // Start is called before the first frame update
    void Awake()
    {
        
        progressbar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
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
    public void startGame()
    {
        GameObject gameLogic = GameObject.FindGameObjectWithTag("GameLogic");
        gameLogic.GetComponent<GameStats>().setAllTeamsNotReady();

        string sceneToLoad = "";
        sceneToLoad = "SampleScene";
        sceneToLoad = "PickTopicsScene";
        print("Loading " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}

