using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerOutCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("out");
            this.GetComponentInParent<LazerController>().OnExit();
        }
    }
}
