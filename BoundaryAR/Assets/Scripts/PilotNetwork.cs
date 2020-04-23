using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotNetwork : MonoBehaviour
{
    static public PilotNetwork instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupPilot()
    {
        transform.Find("Temp").gameObject.SetActive(true);
        transform.parent = GameObject.Find("Map").transform; // set parent of pilot to "map"
        transform.localScale = new Vector3(1, 1, 1);
        gameObject.SetActive(true);
    }
}
