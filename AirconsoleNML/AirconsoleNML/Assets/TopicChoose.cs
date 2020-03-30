using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicChoose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] topics = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameStats>().getTopics();

    }


}
