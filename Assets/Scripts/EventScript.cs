using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cube;
    public GameObject sphere;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plateEvent() {

        cube.GetComponent<MeshRenderer>().enabled = true;
        sphere.GetComponent<Collider>().enabled = true;

    }

    public void plateEvent2ElectricBoogaloo()
    {

    }
}
