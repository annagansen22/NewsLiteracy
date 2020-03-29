using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryScreen : MonoBehaviour
{

    private Progressbar progressbar;
    // Start is called before the first frame update
    void Awake()
    {
        progressbar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (progressbar.allTeamsReady()) {
            print("Loading sampleScene");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
