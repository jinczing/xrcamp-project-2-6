using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChildrenMeshColliderConvex : MonoBehaviour
{
    private MeshCollider[] colliders;

    private void Awake()
    {
        colliders = gameObject.GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider collider in colliders)
        {
            collider.convex = true;
        }
    }
}
