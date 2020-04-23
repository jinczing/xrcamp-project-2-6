using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerInCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.GetComponentInParent<LazerController>().OnEnter();
            this.GetComponent<BoxCollider>().size += new Vector3(0, 0, 6.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.GetComponentInParent<LazerController>().OnExit();
            this.GetComponent<BoxCollider>().size -= new Vector3(0, 0, 6.5f);
        }
    }
}
