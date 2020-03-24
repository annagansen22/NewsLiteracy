using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    private GameObject teams;
    public GameObject sliderObject;
    public GameObject textObject;

    private TextMeshProUGUI text;
    private Slider slider;

    private int amountOfTeams;
    private int amountOfReadyTeams;
    // Start is called before the first frame update
    void Start()
    {
        teams = GameObject.FindGameObjectWithTag("Teams");
        text = textObject.GetComponent<TextMeshProUGUI>();
        slider = sliderObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        amountOfTeams = teams.GetComponent<Teams>().amountOfTeams();
        amountOfReadyTeams = teams.GetComponent<Teams>().amountOfReadyTeams();
        slider.value = (float) amountOfReadyTeams / amountOfTeams;
        text.text = amountOfReadyTeams + "/" + amountOfTeams + " Teams Ready";
    }
}
