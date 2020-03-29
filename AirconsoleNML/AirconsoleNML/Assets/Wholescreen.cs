using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wholescreen : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region SINGLETON PATTERN
    public static Wholescreen _instance;
    public static Wholescreen Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Wholescreen>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("ScreenContainer");
                    _instance = container.AddComponent<Wholescreen>();
                }
            }

            return _instance;
        }
    }
    #endregion
}
