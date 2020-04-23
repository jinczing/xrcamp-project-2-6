using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNetwork : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = GameObject.Find("Anchor").transform.Find("Map").transform;
        //this.transform.position = door.transform.position;
        //this.transform.rotation = door.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
