using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMovement : MonoBehaviour
{
    [SerializeField] private bool isMove;
    [SerializeField] private bool isRight;
    [SerializeField] private float k;
    [SerializeField] private float amplitude;
    private Vector3 center;
    private Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        v = Vector3.zero;
        center = this.transform.position + (isRight ? this.transform.right * amplitude:this.transform.right * -amplitude);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove)
        {
            v += k * (center - this.transform.position);
            this.transform.position += v;
        }
    }
}
