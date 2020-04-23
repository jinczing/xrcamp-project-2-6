using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfraredRayCast : MonoBehaviour
{
    public float dist = 31.2f;
    public GameObject manager;

    private Vector3 rayDirect;
    private Ray ray;
    private RaycastHit hit;
    private int playerLayer;
    private RayCastActions actions;
    private LineRenderer lr;

    private void CastRay()
    {
        rayDirect = transform.TransformVector(Vector3.forward);
        ray = new Ray(transform.position, rayDirect);
        lr.SetPosition(0, new Vector3(0, 0, dist));
        Debug.DrawRay(transform.position, rayDirect * dist, Color.red);
    }

    private void Awake()
    {
        playerLayer = LayerMask.GetMask("Player");
        actions = manager.GetComponent<RayCastActions>();
        lr = GetComponent<LineRenderer>();
        CastRay();
    }

    private void Update()
    {
        CastRay();
        if (Physics.Raycast(ray, out hit, dist, playerLayer))
        {
            if (actions != null)
            {
                actions.DoSomething();
            }
        }
    }
}
