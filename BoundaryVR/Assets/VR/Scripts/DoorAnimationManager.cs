using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationManager : MonoBehaviour
{
    public Animator anim;
    public string playerCameraRigName = "[Player_CameraRig]";
    public GameObject player;
    public float doorOpenDistance = 2f;

    private float dist;

    private void Animate()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < 2f)
        {
            anim.SetBool("character_nearby", true);
        }
        else
        {
            anim.SetBool("character_nearby", false);
        }
    }
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Animate();
    }

}
