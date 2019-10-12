using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    bool up;
    // Start is called before the first frame update
    void Start()
    {
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
                StartCoroutine("MoveRight");
                StartCoroutine("RotateRight");
                up = !up;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
                StartCoroutine("MoveLeft");
                StartCoroutine("RotateLeft");
                up = !up;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine("MoveUp");
            StartCoroutine("RotateUp");
            up = !up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine("MoveDown");
            StartCoroutine("RotateDown");
            up = !up;
        }
    }

    public IEnumerator MoveRight()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition;
        if (up)
        {
            FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1.5f, -0.5f, 0f);
        }
        else
        {
            FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(1.5f, 0.5f, 0f);
        }
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
        Vector3 FinalPosition;
        if (up)
        {
            FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(-1.5f, -0.5f, 0f);
        }
        else
        {
            FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(-1.5f, 0.5f, 0f);
        }
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


    public IEnumerator MoveUp()
    {
        Vector3 InitialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 FinalPosition;
        if (up)
        {
            FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, -0.5f, 1.5f);
        }
        else
        {
            FinalPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(0f, 0.5f, 1.5f);
        }
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
        Vector3 degrees = new Vector3(90f, 0, 0);
        Quaternion From = this.transform.rotation;
        Quaternion To = From * Quaternion.Euler(degrees);
        for (int i = 1; i <= 15; i++)
        {
            this.transform.rotation = Quaternion.Slerp(From, To, (float)i / 15f);            //Debug.Log(i/10);
            yield return null;
        }
    }
}

