using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNetwork : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = GameObject.Find("Anchor").transform.Find("Map").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
