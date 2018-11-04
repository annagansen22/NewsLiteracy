using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemCollection : MonoBehaviour {

    public Sprite sprite;
    public GameObject fieldItem;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () { 

        spriteRenderer = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
	    getSprite();	
	}

    public void collected( ) {

        gameObject.transform.Find("ItemImage").GetComponent<Image>().sprite = fieldItem.GetComponent<ItemField>().sprite;

    }

    private void getSprite() {
        spriteRenderer.sprite = sprite;
    }
}
