using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System.Linq;
using TMPro;

public class ChosenTopics : MonoBehaviour
{
    void Start()
    {
        // Set Controller View
        string[] topics = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getChosenTopics();

        string text = "Dit zijn de top 3 onderwerpen geworden waar het spel over zal gaan:\n\n1. "+topics[0] + "\n2. "+ topics[1] +"\n3. "+ topics[2];

        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = text;

        //If this is uncommented, the scene works on a 5 sec timer instead of when all teams pressed okay
        StartCoroutine(WaitForSecondsThenSwitchScene(10));
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
