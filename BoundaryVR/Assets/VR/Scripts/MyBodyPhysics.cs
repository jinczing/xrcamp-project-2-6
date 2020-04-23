using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MyBodyPhysics : VRTK_BodyPhysics
{
    
    protected override void GenerateBodyCollider()
    {
        if (bodyColliderContainer == null)
        {
            if (customBodyColliderContainer != null)
            {
                bodyColliderContainer = InstantiateColliderContainer(customBodyColliderContainer, BODY_COLLIDER_CONTAINER_NAME, playArea);
                bodyCollider = bodyColliderContainer.GetComponent<CapsuleCollider>();
            }
            else
            {
                bodyColliderContainer = CreateColliderContainer(BODY_COLLIDER_CONTAINER_NAME, playArea); 
            }

            bodyColliderContainer.gameObject.layer = LayerMask.NameToLayer("Player");
            bodyCollider = GenerateCapsuleCollider(bodyColliderContainer, bodyRadius);
            bodyCollider.isTrigger = false;

            GenerateFootCollider();
        }
    }


    protected override GameObject CreateColliderContainer(string name, Transform parent)
    {
        GameObject generatedContainer = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, name));
        generatedContainer.transform.SetParent(parent);
        generatedContainer.transform.localPosition = Vector3.zero;
        generatedContainer.transform.localRotation = Quaternion.identity;
        generatedContainer.transform.localScale = Vector3.one;

        generatedContainer.layer = LayerMask.NameToLayer("Player");
        VRTK_PlayerObject.SetPlayerObject(generatedContainer, VRTK_PlayerObject.ObjectTypes.Collider);

        return generatedContainer;
    }
}
