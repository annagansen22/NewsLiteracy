using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlineData
{
    private string topic;
    private string trueHeadline;
    private string keyword;

    public HeadlineData(string t, string k, string h)
    {
        topic = t;
        keyword = k;
        trueHeadline = h;
    }

    public string getTopic()
    {
        return topic;
    }

    public string getTrueHeadline()
    {
        return trueHeadline;
    }

    public string getKeyword()
    {
        return keyword;
    }
}
