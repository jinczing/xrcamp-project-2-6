using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class DoorController : MonoBehaviour
{
    public Animator animator;

    private PhotonView view;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        //view.viewID = 1;
        isOpen = animator.GetBool("open");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            this.Act();
        }
    }

    public void Act()
    {
        animator.SetBool("open", !isOpen);
        view.RPC("RPC_Animate_Door", PhotonTargets.Others, isOpen);
        isOpen = !isOpen;
        
    }

    [PunRPC]
    void RPC_Animate_Door(bool isOpen)
    {
        Debug.Log("RPC");
        animator.SetBool("open", !isOpen);
    }
}
