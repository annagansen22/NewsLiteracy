using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealFakeData
{
    private string topic;
    private string question;
    private bool truth;

    public RealFakeData(string t, string q, bool val)
    {
        topic = t;
        question = q;
        truth = val;
    }

    public string getTopic()
    {
        return topic;
    }

    public string getQuestion()
    {
        return question;
    }

    public bool getTruth()
    {
        return truth;
    }
}
