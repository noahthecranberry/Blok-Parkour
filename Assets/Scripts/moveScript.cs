﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveScript : MonoBehaviour
{
    public Transform Up;
    public Transform XDown;
    public Transform ZDown;

    public GameObject counter;
    Text counterText;
    public int moves;

// public GameObject Player;

    [SerializeField]
    int collisionNumber = 0;

    public bool one;
    public bool two;

    public bool inputUp;

    public float Rx; //For rotation.
    public float Ry;
    public float Rz;

    public float Dx; //For movement.
    public float Dy;
    public float Dz;

    // Start is called before the first frame update
    void Start()
    {
        one = false;
        two = false;
        inputUp = true;

        moves = 0;
        counterText = counter.GetComponent<Text>();
        counterText.text = "No moves yet";
        
        //up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputUp)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) //"forward
            {
                StartCoroutine("RestInput");
                if (!one && !two) //up
                {

                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("RotateXDown");

                    one = true;
                    two = false;

                    Debug.Log(one);
                    Debug.Log(two);

                    moves += 1;
                    counterText.text = moves.ToString();
                    
                }

                else if (one && !two) //down x
                {
                    SetMVals(1.5f, 0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("RotateUp");

                    one = false;
                    two = false;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

                else if (!one && two) // down z
                {
                    SetMVals(1f, 0f, 0f);
                    StartCoroutine("Shift");

                    one = false; //No change
                    two = true;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two) //up
                {
                    SetMVals(-1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("RotateXDown");

                    one = true;
                    two = false;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

                else if (one && !two) //down x
                {
                    SetMVals(-1.5f, 0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("RotateUp");

                    one = false;
                    two = false;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

                else if (!one && two) //down z
                {
                    SetMVals(-1f, 0f, 0f);
                    StartCoroutine("Shift");

                    one = false; //No change.
                    two = true;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two) //up
                {
                    SetMVals(0f, -0.5f, -1.5f);
                    StartCoroutine("Shift");
                    StartCoroutine("RotateZDown");

                    one = false;
                    two = true;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

                else if (one && !two) //down x
                {
                    SetMVals(0f, 0f, -1f);
                    StartCoroutine("Shift");

                    one = true;
                    two = false; //No Change

                    moves += 1;
                    counterText.text = moves.ToString();
                }


                else if (!one && two) //down z
                {
                    SetMVals(0f, 0.5f, -1.5f);
                    StartCoroutine("Shift");
                    StartCoroutine("RotateUp");

                    one = false;
                    two = false;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two) //up
                {
                    SetMVals(0f, -0.5f, 1.5f);
                    StartCoroutine("Shift");
                    StartCoroutine("RotateZDown");

                    one = false;
                    two = true;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

                else if (one && !two) //down x
                {
                    SetMVals(0f, 0f, 1f);
                    StartCoroutine("Shift");

                    one = true;
                    two = false; //No change

                    moves += 1;
                    counterText.text = moves.ToString();
                }

                else if (!one && two) //down z
                {
                    SetMVals(0f, 0.5f, 1.5f);
                    StartCoroutine("Shift");
                    StartCoroutine("RotateUp");

                    one = false;
                    two = false;

                    moves += 1;
                    counterText.text = moves.ToString();
                }

            }
        }
    }

    public void SetMVals(float myx, float myy, float myz)
    {
        Dx = myx;
        Dy = myy;
        Dz = myz;
    }

    public IEnumerator RestInput()
    {
        inputUp = false;
        yield return new WaitForSeconds(0.4f);
        checkLose();

        inputUp = true;
    }

    public IEnumerator RotateUp()
    {
        Quaternion from = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
        Quaternion to = new Quaternion(Up.rotation.x, Up.transform.rotation.y, Up.transform.rotation.z, Up.transform.rotation.w);

        for (float j = 1; j <= 15; j++)
        {
            Quaternion newRotation = Quaternion.Lerp(from, to, j / 15);
            this.transform.rotation = new Quaternion(newRotation.x, newRotation.y, newRotation.z, newRotation.w);
            yield return null;
        }
    }

    public IEnumerator RotateXDown()
    {
        Quaternion from = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
        Quaternion to = new Quaternion(XDown.rotation.x, XDown.transform.rotation.y, XDown.transform.rotation.z, XDown.transform.rotation.w);

        for (float j = 1; j <= 15; j++)
        {
            Quaternion newRotation = Quaternion.Lerp(from, to, j/15);
            this.transform.rotation = new Quaternion(newRotation.x, newRotation.y, newRotation.z, newRotation.w);
            yield return null;
        }
    }

    public IEnumerator RotateZDown()
    {
        Quaternion from = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
        Quaternion to = new Quaternion(ZDown.rotation.x, ZDown.transform.rotation.y, ZDown.transform.rotation.z, ZDown.transform.rotation.w);

        for (float j = 1; j <= 15; j++)
        {
            Quaternion newRotation = Quaternion.Lerp(from, to, j / 15);
            this.transform.rotation = new Quaternion(newRotation.x, newRotation.y, newRotation.z, newRotation.w);
            yield return null;
        }
    }

    public IEnumerator Shift()
    {
        Vector3 InitialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 FinalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z) + new Vector3(Dx, Dy, Dz);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }

    public void increment() {
        //if()
    }

    public void decrement() {

    }

    void checkLose()
    {
        if((collisionNumber != 2 && (one || two)) || (collisionNumber != 1 && (!one && !two) ))
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-500f, 500f), Random.Range(100f, 500f), Random.Range(-500f, 500f)));
            Debug.Log("you lose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We entered" + other);
        collisionNumber++;
    }

    private void OnTriggerExit(Collider other)
    {
        collisionNumber--;
        
    }

}


    