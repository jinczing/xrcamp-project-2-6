using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
    
    [SerializeField]  private GameObject[] lights;
    [SerializeField]  private GameObject[] lazers;
    [SerializeField] private AudioClip[] clips; // 0: turn on machine, 1: turn off machine, 2: alarm
    private AudioSource source;
    private bool isEnter;

    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        source = GetComponent<AudioSource>();
    }


    public void OnEnter()
    {
        if (isEnter) return;
        source.PlayOneShot(clips[0]);
        //source.PlayOneShot(clips[2]);
        foreach(GameObject light in lights)
        {
            light.SetActive(false);
        }
        foreach (GameObject lazer in lazers)
        {
            lazer.SetActive(true);
        }
        isEnter = true;
    }

    public void OnExit()
    {
        if (!isEnter) return;
        source.PlayOneShot(clips[1]);
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }
        foreach (GameObject lazer in lazers)
        {
            lazer.SetActive(false);
        }
        isEnter = false;
    }
}
