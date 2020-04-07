using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicChoose : MonoBehaviour
{
    Tuple<string, int> sport = new Tuple<string, int> ("sport", 0 );
    Tuple<string, int> actueel_nieuws = new Tuple<string, int>("actueel_nieuws", 0);
    Tuple<string, int> beroemdheden = new Tuple<string, int>("beroemdheden", 0);
    Tuple<string, int> politiek = new Tuple<string, int>("politiek", 0);
    Tuple<string, int> klimaat = new Tuple<string, int>("klimaat", 0);
    Tuple<string, int> misdaad = new Tuple<string, int>("misdaad", 0);

    private bool noTopicsSet = true;
    public void voteSport()
    {
        int i = sport.Item2 + 1;
        sport = new Tuple<string, int>("sport", i);
    }
    public void voteActueel_nieuws()
    {
        int i = actueel_nieuws.Item2 + 1;
        actueel_nieuws = new Tuple<string, int>("actueel_nieuws", i);
    }

    public void voteBeroemdheden()
    {
        int i = beroemdheden.Item2 + 1;
        beroemdheden = new Tuple<string, int>("beroemdheden", i);
    }

    public void votePolitiek()
    {
        int i = politiek.Item2 + 1;
        politiek = new Tuple<string, int>("politiek", i);
    }

    public void voteKlimaat()
    {
        int i = klimaat.Item2 + 1;
        klimaat = new Tuple<string, int>("klimaat", i);
    }

    public void voteMisdaad()
    {
        int i = misdaad.Item2 + 1;
        misdaad = new Tuple<string, int>("misdaad", i);
    }

    public string[] getThreeTopics()
    {
        List<Tuple<string, int>> voteList = new List<Tuple<string, int>> { sport, actueel_nieuws, beroemdheden, politiek, klimaat, misdaad };
        voteList.Sort((a, b) => b.Item2.CompareTo(a.Item2));
        List<Tuple<string, int>> sortedList = new List<Tuple<string, int>> { voteList[0], voteList[1], voteList[2] };
        string[] topicList = new string[3];
        int i = 0;
        foreach (Tuple<string, int> t in sortedList)
        {
            topicList[i] = t.Item1;
            print("Topic " + i + ": " + t.Item1);
            i += 1;
        }
        return topicList;
    }

    public void Update()
    {
        Progressbar progressbar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
        //if all teams are ready
        if (progressbar.allTeamsReady() && noTopicsSet)
        {
            setTopics();
            noTopicsSet = false;
        }
    }


    //Do this when all players voted
    public void setTopics()
    {
        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().setChosenTopics(getThreeTopics());
    }
}
