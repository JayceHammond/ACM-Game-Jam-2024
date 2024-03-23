using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGrabbable : MonoBehaviour
{
    private Rigidbody ObjectRigidBody;
    private Transform ObjectGrabPointTransform;

    public void Awake(){
        ObjectRigidBody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform ObjectGrabPointTransform){
        this.ObjectGrabPointTransform = ObjectGrabPointTransform;
        ObjectRigidBody.useGravity = false;
    }

    public void Drop(){
        this.ObjectGrabPointTransform = null;
        ObjectRigidBody.useGravity = true;
    }

    private void FixedUpdate(){
        if(ObjectGrabPointTransform != null){
            Vector3 newPosition = Vector3.Lerp(transform.position, ObjectGrabPointTransform.position, Time.deltaTime * 10f);
            ObjectRigidBody.MovePosition(newPosition);
        }
    }
}
