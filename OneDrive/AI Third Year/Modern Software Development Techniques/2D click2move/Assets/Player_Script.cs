using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour {

    
    //Private components/variables
    private CircleCollider2D col;
    private Vector3 targetPos;
    private Vector3 currentPos;

    //Public components
    public Camera cam;
    public Animator anim;

    //Public variables
    private bool followMouse;
    public float playerSpeed;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D>();
        followMouse = false;
        endWalkAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        // If left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            onMouseClick();
            rotateToMouse();
        }
        if (followMouse)
        {
            moveToMouse();
        }
	}

    private void rotateToMouse()
    {
        //Get mouse coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = (mousePos.x - transform.position.x);
        float y = (mousePos.y - transform.position.y);
        float xAbs = Math.Abs(x);
        float yAbs = Math.Abs(y);

        Debug.Log("x: " + x + ", y: " + y);
        //Set angles for animation
        
        if (x > 0 && y > 0) //Right Up
        {
            anim.SetInteger("WalkDir", 1);
        }
        else if (x > 0 && y < 0) //Right Down
        {
            anim.SetInteger("WalkDir", 2);
        }
        else if (x < 0 && y > 0) //Left Up
        {
            anim.SetInteger("WalkDir", 0);
        }
        else if (x < 0 && y < 0) //Left Down
        {
            anim.SetInteger("WalkDir", 3);
        }
    }

    private void onMouseClick()
    {
        bool allowMove = true;
        if (allowMove)
        {
            followMouse = true;
            //Get mouse positions is VIEWPORT setting, not WORLDVIEW
            targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            //Set speed once again
            anim.speed = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Wall")
        {
            //endWalkAnimation();
            //targetPos = transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //endWalkAnimation();
            //targetPos = transform.position;
        }
    }

    private void moveToMouse()
    {

        // Movement calculations
        float delta = (playerSpeed/100) + Time.deltaTime; //* Vector3.Distance(transform.position, targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, delta);

        //Check if arrived
        if (transform.position == targetPos)
        {
            followMouse = false;
            endWalkAnimation();
        }

    }

    private void endWalkAnimation()
    {
        int dir = anim.GetInteger("WalkDir");
        anim.speed = 0.0f;
        if (dir == 0)
        {
            anim.Play("Walk_Left_Up", 0, 0);
        }
        else if (dir == 1)
        {
            anim.Play("Walk_Right_Up", 0, 0);
        }
        else if (dir == 2)
        {
            anim.Play("Walk_Right_Down", 0, 0);
        }
        else if (dir == 3)
        {
            anim.Play("Walk_Right_Down", 0, 0);
        }
    }
}
