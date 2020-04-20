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
        view.viewID = 1;
        isOpen = animator.GetBool("open");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Act()
    {
        animator.SetBool("open", !isOpen);
        isOpen = !isOpen;
    }
}
