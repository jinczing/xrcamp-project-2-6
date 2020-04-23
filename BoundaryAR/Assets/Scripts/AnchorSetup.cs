using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class AnchorSetup : MonoBehaviour
{
    //public GameObject door;
    [SerializeField] private Transform[] doors;


    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform door in doors)
        {
            GameObject doorTemp = PhotonNetwork.Instantiate("Door", Vector3.zero, Quaternion.identity, 0);
            doorTemp.transform.parent = transform.Find("Map").transform;
            doorTemp.transform.localScale = new Vector3(1, 1, 1);
            doorTemp.transform.localPosition = door.transform.localPosition;
            doorTemp.transform.localRotation = door.transform.localRotation;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
