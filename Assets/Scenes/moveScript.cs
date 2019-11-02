using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    //bool up;

    bool one;
    bool two;

    // Start is called before the first frame update
    void Start()
    {
        one = false;
        two = false;
        //up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!one && !two)
            {
                one = !one;
                StartCoroutine("MoveRight");
                StartCoroutine("RotateRight");
                Debug.Log(one);
                Debug.Log(two);
            }

            else if (one && !two)
            {
                Debug.Log("Hello2");
                one = !one;
            }

            else if (!one && two)
            {

            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (!one && !two)
            {
                two = !two;
            }

            else if (one && !two)
            {
                one = !one;
            }

            else if (!one && two)
            {

            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (!one && !two)
            {
                two = true;
            }

            else if (one && !two)
            {

            }


            else if (!one && two)
            {
                two = !two;
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (!one && !two)
            {
                two = true;
            }

            else if (one && !two)
            {

            }

            else if (!one && two)
            {
                two = true;

            }

        }
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

    public IEnumerator RotateUp()
    {
        Vector3 degrees = new Vector3(90f , 0f, 0f);
        Quaternion From = this.transform.rotation;
        Quaternion To = From * Quaternion.Euler(degrees);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.rotation = Quaternion.Slerp(From, To, (float)i / 15f);            //Debug.Log(i/10);
            yield return null;
        }
    }

    public IEnumerator MoveRight()
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

    public IEnumerator RotateRight()
    {
        Vector3 degrees = new Vector3(0, 0, -90f);
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
        Vector3 FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(-1.5f, 0.5f, 0f);
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
