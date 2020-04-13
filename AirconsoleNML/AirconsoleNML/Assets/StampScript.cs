using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StampScript : MonoBehaviour
{

    public Sprite trueIm;
    public Sprite falseIm;
    private Image currentImage;

    public void Start()
    {
        currentImage = GetComponent<Image>();
        // set inactive as default
        gameObject.SetActive(false);
    }
    public void showStamp(bool b)
    {
        if (b) currentImage.sprite = trueIm;
        else if (!b) currentImage.sprite = falseIm;
        gameObject.SetActive(true);
    }

}
