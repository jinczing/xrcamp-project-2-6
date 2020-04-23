using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkTracker : MonoBehaviour
{
    [SerializeField] private Transform target;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = transform.worldToLocalMatrix * target.position;
        this.transform.localRotation = target.rotation;
    }

    public void SetupIkTracker()
    {
        this.transform.parent = GameObject.Find("Map").transform;
    }
}
