using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryScreen : MonoBehaviour
{

    private Progressbar progressbar;
    private void Awake()
    {     
        progressbar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
    }

    private void Start()
    {
        GameObject gameLogic = GameObject.FindGameObjectWithTag("GameLogic");
        gameLogic.GetComponent<GameL>().testInitialization();
    }

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
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<AIComponent>().nextScene(SceneManager.GetActiveScene().name);

        //string sceneToLoad = "";
        //sceneToLoad = "SampleScene";
        //sceneToLoad = "PickTopicsScene";
        //print("Loading " + sceneToLoad);
        //SceneManager.LoadScene(sceneToLoad);
    }
}

