using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public int GoalNumber;
    public int CurrentTime;
    public GameObject Cube;
    public bool Done;
    // Start is called before the first frame update
    void Start()
    {
        GoalNumber = 30;
        CurrentTime = 0;
        Done = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Done)
        {
            CurrentTime++;
            if (CurrentTime > GoalNumber)
            {
                Done = true;
                StartCoroutine("ProtocolFinish");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentTime = 0;
    }

    private IEnumerator ProtocolFinish()
    {
        for(int i = 1;  i <= 40; i++)
        {
            Cube.transform.position -= new Vector3(0f, 0.05f, 0f);
            yield return null;
            //Switch scene here.
        }
    }
}
