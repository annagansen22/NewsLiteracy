using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingData
{
    private string topic;
    private Dictionary<string, string> dict;

    public MatchingData(string t, Dictionary<string, string> d)
    {
        topic = t;
        dict = d;
    }

    public string getTopic()
    {
        return topic;
    }

    public Dictionary<string, string> getDict()
    {
        return dict;
    }

    public string getPurposeOfHeadline(string p)
    {
        return dict[p];
    }
}
