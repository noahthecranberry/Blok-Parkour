using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{

    [SerializeField]
    int collisionNumber = 0;

    public bool one;
    public bool two;

    int randInt;

    //private List<string> force;

// public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

    public void checkLose(GameObject Player)
    {
        if ((collisionNumber != 2 && (one || two )) || (collisionNumber != 1 && (!one && !two)))
        {
            Player = GameObject.FindWithTag("Player");
            Player.GetComponent<Rigidbody>().AddForce( new Vector3(Random.Range(-50f, 50f), Random.Range(10f, 50f), Random.Range(-50f, 50f)));
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

    private void randForce()
    {
        
    }

    
}
