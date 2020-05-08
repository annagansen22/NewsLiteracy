using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    void Start()
    {
        string teamName = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().teams[0].getTeamName();
        string teamFollowers = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().teams[0].getScore().ToString();
        GameObject.FindGameObjectWithTag("ScreenText").GetComponent<TextMeshProUGUI>().text = "<b>" + teamName +" has won with " + teamFollowers +" followers!</b>";
    }
}
