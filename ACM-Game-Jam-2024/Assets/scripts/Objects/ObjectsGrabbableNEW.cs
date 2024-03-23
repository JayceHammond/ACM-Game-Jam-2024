using UnityEngine;

public class ObjectsGrabbableNEW : MonoBehaviour
{
    private Rigidbody ObjectRigidBody;
    private Transform ObjectGrabPointTransform;

    private void Awake()
    {
        ObjectRigidBody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabPoint)
    {
        ObjectGrabPointTransform = grabPoint;
        ObjectRigidBody.useGravity = false;
        ObjectRigidBody.isKinematic = true;
        transform.SetParent(ObjectGrabPointTransform);
        transform.localPosition = Vector3.zero;
    }

    public void Drop()
    {
        ObjectRigidBody.useGravity = true;
        ObjectRigidBody.isKinematic = false;
        transform.SetParent(null);
    }
}