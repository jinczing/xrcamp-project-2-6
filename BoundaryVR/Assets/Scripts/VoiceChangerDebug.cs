using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceChangerDebug : MonoBehaviour
{
    private VoiceChangerFilter filter;

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<VoiceChangerFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            filter._pitch = Random.Range(0, 2.0f);
            filter._formant = Random.Range(0.5f, 1.5f);
        }
    }
}
