using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGrabbable : MonoBehaviour
{
    private Rigidbody ObjectRigidBody;
    private Transform ObjectGrabPointTransform;
    private bool isGrab;

    public void Awake(){
        ObjectRigidBody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform ObjectGrabPointTransform, GameObject grabbedObj, bool grabbed){
        isGrab = true;
        this.ObjectGrabPointTransform = ObjectGrabPointTransform;
        this.ObjectGrabPointTransform.position = new Vector3(ObjectGrabPointTransform.position.x, ObjectGrabPointTransform.position.y + grabbedObj.GetComponent<Collider>().bounds.size.y, ObjectGrabPointTransform.position.z);
        ObjectRigidBody.useGravity = false;
    }

    public void Drop(){
        Debug.Log(this.ObjectGrabPointTransform);
        this.ObjectGrabPointTransform = null;
        isGrab = false;
        ObjectRigidBody.useGravity = true;
        //ObjectRigidBody.useGravity = true;
    }

    private void FixedUpdate(){
        if(isGrab){
            Vector3 newPosition = Vector3.Lerp(transform.position, ObjectGrabPointTransform.position, Time.deltaTime * 10f);
            ObjectRigidBody.MovePosition(newPosition);
        }else{
            //Debug.Log("Not a problem");
        }
    }


    void OnCollisionEnter(Collision col){
        
    }
}
