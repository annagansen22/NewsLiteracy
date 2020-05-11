using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationData
{
    private string game;
    private string information;

    public InformationData(string g, string i)
    {
        game = g;
        information = i;
    }

    public string getGame()
    {
        return game;
    }

    public string getInformation()
    {
        return information;
    }
}
