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

                else if (one && !two)
                {
                    SetRVals(0f, 0f, -90f);
                    SetMVals(1.5f, 0.5f, 0f);
                    StartCoroutine("Shift");
                    StartCoroutine("Rotate");

                    one = false;
                    two = false;

                }

                else if (!one && two)
                {
                    StartCoroutine("MoveRightDD");
                    StartCoroutine("SpinRight");
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two)
                {
                    SetRVals(0f, 0f, 90f);
                    one = !one;
                    StartCoroutine("MoveLeft");
                    StartCoroutine("Rotate");
                }

                else if (one && !two)
                {
                    SetRVals(0f, 0f, 90f);
                    one = !one;
                    StartCoroutine("MoveLeftU");
                    StartCoroutine("Rotate");
                }

                else if (!one && two)
                {
                    StartCoroutine("ShiftLeft");
                    StartCoroutine("SpinLeft");
                }

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two)
                {

                    StartCoroutine("MoveBackD");
                    StartCoroutine("RotateBack");
                    two = true;
                }

                else if (one && !two)
                {
                    StartCoroutine("SpinRight");
                    StartCoroutine("MoveBackB");
                }


                else if (!one && two)
                {
                    two = !two;
                    StartCoroutine("MoveBack");
                    StartCoroutine("RotateBack");
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine("RestInput");
                if (!one && !two)
                {
                    two = true;
                    StartCoroutine("MoveUp");
                    StartCoroutine("RotateUp");
                    //Debug.Log("HELLO");

                }

                else if (one && !two)
                {
                    StartCoroutine("MoveUpD");
                    StartCoroutine("RotateUpD");
                    
                }

                else if (!one && two)
                {
                    StartCoroutine("MoveUpU");
                    StartCoroutine("RotateUp");
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
    public IEnumerator MoveUp()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, -0.5f, 1.5f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }

    public IEnumerator MoveUpD() //moving forward from down pos to down pos (!2,1) to (!2,1)
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, 0f, 1f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }
   
    public IEnumerator RotateUp()
    {
        Vector3 degrees = new Vector3(90f, 0f, 0f);
        Quaternion From = this.transform.rotation;
        Quaternion To = From * Quaternion.Euler(degrees);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.rotation = Quaternion.Slerp(From, To, (float)i / 15f);            //Debug.Log(i/10);
            yield return null;
        }
    }

    public IEnumerator RotateUpD() //spinning forward from down pos to down pos (!2,1) to (!2,1)
    {
        Vector3 degrees = new Vector3(0f, 90f, 0f);
        Quaternion From = this.transform.rotation;
        Quaternion To = From * Quaternion.Euler(degrees);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.rotation = Quaternion.Slerp(From, To, (float)i / 15f);            //Debug.Log(i/10);
            yield return null;
        }
    }
    public IEnumerator MoveUpU() //From down position to up
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, .5f, 1.5f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }

    public IEnumerator MoveRight() //up to down
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1.5f, -0.5f, 0f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }
    public IEnumerator MoveRightDD() //down to down
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1.5f, 0f, 0f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }

    public IEnumerator MoveRightU()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1.5f, .5f, 0f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
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

    public IEnumerator ShiftRight()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1f, 0f, 0f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }
    public IEnumerator SpinRight()
    {
        Vector3 degrees = new Vector3(0, -90f, 0f);
        Quaternion From = this.transform.rotation;
        Quaternion To = From * Quaternion.Euler(degrees);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.rotation = Quaternion.Slerp(From, To, (float)i / 15f);            //Debug.Log(i/10);
            yield return null;
        }
    }
    public IEnumerator MoveLeft()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(-1.5f, -0.5f, 0f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }

    public IEnumerator RotateLeft()
    {
        Vector3 degrees = new Vector3(0, 0, 90f);
        Quaternion From = this.transform.rotation;
        Quaternion To = From * Quaternion.Euler(degrees);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.rotation = Quaternion.Slerp(From, To, (float)i / 15f);            //Debug.Log(i/10);
            yield return null;
        }
    }

    public IEnumerator ShiftLeft()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(-1f, 0f, 0f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }
    public IEnumerator SpinLeft()
    {
        Vector3 degrees = new Vector3(0, 90f, 0f);
        Quaternion From = this.transform.rotation;
        Quaternion To = From * Quaternion.Euler(degrees);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.rotation = Quaternion.Slerp(From, To, (float)i / 15f);            //Debug.Log(i/10);
            yield return null;
        }
    }

    public IEnumerator MoveLeftU() //From down position to up
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(-1.5f, 0.5f, 0f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }
    public IEnumerator MoveBack() //moves back and up 
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, 0.5f, -1f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }

    public IEnumerator MoveBackB() //moves back 
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, 0f, -1f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }
    public IEnumerator MoveBackD()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, -.5f, -1.5f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }

    public IEnumerator RotateBack()
    {
        Vector3 degrees = new Vector3(-90, 0, 0f);
        Quaternion From = this.transform.rotation;
        Quaternion To = From * Quaternion.Euler(degrees);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.rotation = Quaternion.Slerp(From, To, (float)i / 15f);            //Debug.Log(i/10);
            yield return null;
        }
    }

}





/*if (up)
           {
               StartCoroutine("MoveRight");
               StartCoroutine("RotateRight");
           }
           else
           {
               //Do the same stuff but with the other y jump.
           }
           up = !up;
       }
       if (Input.GetKeyDown(KeyCode.LeftArrow))
       {
           if (up)
           {
               StartCoroutine("MoveLeft");
               StartCoroutine("RotateLeft");
           }
           else
           {
               //Do the same stuff but with the other y jump.
           }
           up = !up;*/
