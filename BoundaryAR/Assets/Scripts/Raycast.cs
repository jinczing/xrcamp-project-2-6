using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private LineRenderer lr;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider)
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
            }
        }
        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 5000));
        }
    }
}
