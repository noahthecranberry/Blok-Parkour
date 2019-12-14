using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hardcodedMoveScript : MonoBehaviour
{
    //bool up;

    public bool one;
    public bool two;
    public bool inputUp;

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
                    one = !one;
                    StartCoroutine("MoveRight");
                    StartCoroutine("RotateRight");
                    one = true;

                    Debug.Log(one);
                    Debug.Log(two);

                }

                else if (one && !two)
                {
                    StartCoroutine("MoveRightU");
                    StartCoroutine("RotateRight");
                    one = !one;

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

                    one = !one;
                    StartCoroutine("MoveLeft");
                    StartCoroutine("RotateLeft");
                }

                else if (one && !two)
                {
                    one = !one;
                    StartCoroutine("MoveLeftU");
                    StartCoroutine("RotateLeft");
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

    public IEnumerator RestInput()
    {
        inputUp = false;
        yield return new WaitForSeconds(0.5f);
        inputUp = true;
    }
    public IEnumerator MoveUp()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, -0.5f, 1f);
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
            yield return null;
        }
    

    public IEnumerator RotateUpD() //spinning forward from down pos to down pos (!2,1) to (!2,1)
    {
        Vector3 degrees = new Vector3(0f, 90f, 0f);
            yield return null;
        }
    
    public IEnumerator MoveUpU() //From down position to up
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, .5f, 1f);
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
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1f, -0.5f, 0f);
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
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1f, 0f, 0f);
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
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1f, .5f, 0f);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, (float)i / 15f);
            //Debug.Log(i/10);
            //Debug.Log(this.transform.position);
            yield return null;
        }
    }
    public IEnumerator RotateRight()
    {
        Vector3 degrees = new Vector3(0, 0, -90f);
            yield return null;
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
            yield return null;
       

    }
    public IEnumerator MoveLeft()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(-1f, -0.5f, 0f);
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
            yield return null;
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
            yield return null;
        }

    public IEnumerator MoveLeftU() //From down position to up
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(-1f, 0.5f, 0f);
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
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, -.5f, -1f);
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
            yield return null;
        
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
