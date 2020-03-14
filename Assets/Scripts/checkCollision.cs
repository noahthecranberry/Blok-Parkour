using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollision : MonoBehaviour
{

    GameObject player;
    public GameObject gameEvent;
    private EventScript eventScript;

    // Start is called before the first frame update

    private void Awake()
    {
       player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        eventScript = gameEvent.GetComponent<EventScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       eventScript.plateEvent();
       // if (player
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
