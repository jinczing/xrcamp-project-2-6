using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip[] clips; // 0: open door, 1: close door
    private bool open;
    private bool set;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        set = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(set)
        {
            if (open) source.PlayOneShot(clips[0]);
            else source.PlayOneShot(clips[1]);
            Debug.Log("set");
            animator.SetBool("open", open);
            set = false;
        }
        
    }

    [PunRPC]
    void RPC_Animate_Door(bool isOpen)
    {
        Debug.Log("RPC");
        open = !isOpen;
        set = true; 
    }
}
