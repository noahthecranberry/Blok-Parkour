using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollision : MonoBehaviour
{

    GameObject player;
    private moveScript MoveScript;

    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
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
