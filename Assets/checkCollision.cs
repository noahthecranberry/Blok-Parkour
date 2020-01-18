using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollision : MonoBehaviour
{

    public GameObject player;
    private moveScript MoveScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        MoveScript = player.GetComponent<moveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MoveScript.increment();
       // if (player
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
