using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemField : MonoBehaviour {

    public Sprite sprite;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

	}

}
