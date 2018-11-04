using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    private bool moveUp;
    private bool moveDown;
    public float doorSpeed;
    private float y;
	// Use this for initialization
	void Start () {
        bool moveUp = false;
        bool moveDown = false;
        y = transform.position.y;
        }
	
	// Update is called once per frame
	void Update () {
        if (moveUp)
        {
            transform.Translate(Vector3.up * (doorSpeed * Time.deltaTime));
        }
        else if(moveDown)
        {
            transform.Translate(Vector3.up * -(doorSpeed * Time.deltaTime));
        }
		if (transform.position.y > y + 1.5 && moveUp)
        {
            moveUp = false;
            moveDown = true;
        }
        if (transform.position.y <= y && moveDown)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            moveDown = false;
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            moveUp = true;
        }
    }
}
