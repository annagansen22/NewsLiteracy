using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    // For wasd movement
    public float speed;
    Animator anim;

    // For mouse movement
    //public Camera cam;
    //private bool followMouse;
    //private CircleCollider2D col;
    //private Vector3 targetPos;
    //public float followSpeed;

    // For both
    public Collection collection;

    // Use this for initialization
    void Start() {
        speed = 3;
        anim = GetComponent<Animator>();

        //col = GetComponent<CircleCollider2D>();
        //followMouse = false;
    }

    // Update is called once per frame
    void Update() {

        //if (Input.GetMouseButton(0)) {
        //    followMouse = true;
        //    targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
        //    targetPos.z = 0;
        //}
        //if (followMouse) {
        //    MoveToMouse();
        //}

        Movement();

    }

    void Movement() {



        anim.speed = 1;
        //UP
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(0, speed * Time.deltaTime, 0);
            anim.SetInteger("dir", 0);
        }
        //DOWN
        else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            anim.SetInteger("dir", 1);
        }
        //LEFT
        else if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            anim.SetInteger("dir", 2);
        }
        //RIGHT
        else if (Input.GetKey(KeyCode.D)) {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetInteger("dir", 3);

        }
        else {
            anim.speed = 0;
        }

    }


    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Item") {

            collection.itemCollected(other.gameObject);

        }

    }


    //private void MoveToMouse() {
    //    float delta = followSpeed + Time.deltaTime * Vector3.Distance(transform.position, targetPos);
    //    transform.position = Vector3.MoveTowards(transform.position, targetPos, delta);
    //    if (transform.position == targetPos) {
    //        followMouse = false;
    //    }
    //}

}
