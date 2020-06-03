using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingData
{
    private Dictionary<string, string> dict;
    private string item1;
    private string item2;

    public MatchingData(Dictionary<string, string> d, string i1, string i2)
    {
        dict = d;
        item1 = i1;
        item2 = i2;
    }
    public string getItem1()
    {
        return item1;
    }

    public string getItem2()
    {
        return item2;
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
