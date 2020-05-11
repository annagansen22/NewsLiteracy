using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlineScores
{
    private int deviceId;
    private string headline;
    private int fooledTeams;
    private string option;
    private int index;

    public HeadlineScores(int id, string h, int nrOfFooled, string o, int i)
    {
        deviceId = id;
        headline = h;
        fooledTeams = nrOfFooled;
        option = o;
        index = i;
    }

    public int DeviceId { get => deviceId; set => deviceId = value; }
    public string Headline { get => headline; set => headline = value; }
    public int FooledTeams { get => fooledTeams; set => fooledTeams = value; }
    public string Option { get => option; set => option = value; }
    public int Index { get => index; set => index = value; }
}
