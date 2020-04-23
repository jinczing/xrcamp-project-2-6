using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    private bool isPortal;
    // Start is called before the first frame update
    void Start()
    {
        isPortal = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiatePortal()
    {
        if (isPortal) return;
        GameObject portal = PhotonNetwork.Instantiate("Portal", Vector3.zero, Quaternion.identity, 0);
        portal.transform.parent = this.transform;
        portal.transform.localScale = new Vector3(1, 1, 1);
        portal.transform.Find("Portal Particle").transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
        portal.transform.localPosition = new Vector3(-0.13f, 1.7f, -0.38f);
        portal.transform.localRotation = Quaternion.identity;
        portal.transform.parent = transform.parent.parent; // set parent of portal to "Map"
        isPortal = true;
    }
}
