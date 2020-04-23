using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSub : MonoBehaviour
{
    public Transform sub;

    void Update()
    {
        transform.localPosition = sub.localPosition;
        transform.localRotation = sub.localRotation;
    }
}
