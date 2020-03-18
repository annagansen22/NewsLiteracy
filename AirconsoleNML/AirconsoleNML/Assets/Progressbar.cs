using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progressbar : MonoBehaviour
{
    private GameObject teams;
    private int amountOfTeams;
    private int amountTeamsReady;
    // Start is called before the first frame update
    void Start()
    {
        teams = GameObject.FindGameObjectWithTag("Teams");
    }

    // Update is called once per frame
    void Update()
    {
        amountOfTeams = teams.GetComponent<Teams>().amountOfTeams();
    }
}
