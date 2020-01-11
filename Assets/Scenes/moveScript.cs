using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    //bool up;

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
        //up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputUp)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two) //up
                {

                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;

                    Debug.Log(one);
                    Debug.Log(two);

                }

                else if (one && !two) //down x
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, 0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = false;
                    two = false;
                }

                else if (!one && two) // down z
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two) //up
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

                else if (one && !two) //down x
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

                else if (!one && two) //down z
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two) //up
                {

                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

                else if (one && !two) //down x
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }


                else if (!one && two) //down z
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two) //up
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

                else if (one && !two) //down x
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

                else if (!one && two) //down z
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, -0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = true;
                    two = false;
                }

            }
        }
    }

    public void SetRVals(float myx, float myy, float myz)
    {
        Rx = myx;
        Ry = myy;
        Rz = myz;
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
        yield return new WaitForSeconds(0.5f);
        inputUp = true;
    }

    public IEnumerator Rotate()
    {
        for (int j = 0; j < 15; j++)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + Rx / 15, transform.eulerAngles.y + Ry / 15, transform.eulerAngles.z + Rz / 15);
            yield return null;
        }
    }

    public IEnumerator Shift()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(Dx, Dy, Dz);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }
}

    