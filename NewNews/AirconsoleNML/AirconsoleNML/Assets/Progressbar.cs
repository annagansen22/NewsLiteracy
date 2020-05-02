using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    private GameObject gameStats;
    public GameObject sliderObject;
    public GameObject textObject;

    private TextMeshProUGUI text;
    private Slider slider;

    private int amountOfTeams;
    private int amountOfReadyTeams;

    // Start is called before the first frame update
    void Start()
    {
        gameStats = GameObject.FindGameObjectWithTag("GameLogic");
        text = textObject.GetComponent<TextMeshProUGUI>();
        slider = sliderObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        amountOfTeams = gameStats.GetComponent<GameStats>().amountOfTeams();
        amountOfReadyTeams = gameStats.GetComponent<GameStats>().amountOfReadyTeams();
        slider.value = (float) amountOfReadyTeams / amountOfTeams;
        text.text = amountOfReadyTeams + "/" + amountOfTeams + " Teams Ready";
    }
    
    public bool allTeamsReady()
    {
        if (amountOfTeams < 1) return false;
        else return amountOfTeams == amountOfReadyTeams;
    }
}
