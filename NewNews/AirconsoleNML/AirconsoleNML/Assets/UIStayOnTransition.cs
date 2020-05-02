using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStayOnTransition : MonoBehaviour
{
    private void Awake()
    {
        if (transform.parent == null)
        {
            print(gameObject.name + " is attaching itself to screen");
            transform.SetParent(GameObject.FindGameObjectWithTag("Screen").transform, false);

        }
    }
}
