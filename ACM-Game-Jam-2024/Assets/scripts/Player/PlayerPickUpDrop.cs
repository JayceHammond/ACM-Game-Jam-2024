using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour {

    [SerializeField] private Transform PlayerCameraTransform;
    [SerializeField] private Transform ObjectGrabPointTransform;
    [SerializeField] private LayerMask PickUpLayerMask;

    private ObjectsGrabbable ObjectGrabbable;
    public bool grabbed = false;

    private void Update(){
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.forward, Color.red);
        if(Input.GetKeyDown(KeyCode.E) && !grabbed){
            if (ObjectGrabbable == null && !grabbed) {
                float PickUpDistance = 100.0f;
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.forward, out RaycastHit raycastHit, PickUpDistance)) {
                    if (raycastHit.transform.TryGetComponent(out ObjectsGrabbable objectGrabbable)) {
                        grabbed = true;
                        //Debug.Log("Pick up grab: " + grabbed);
                        objectGrabbable.Grab(ObjectGrabPointTransform, objectGrabbable.gameObject, grabbed);
                        //Debug.Log(objectGrabbable.gameObject.name);
                    }
                }
            }

        }
        //Debug.Log("Out if: " + grabbed);
        if(Input.GetKeyDown(KeyCode.E) && grabbed){
            //Debug.Log("In Grabbed if: " + grabbed);
            //Debug.Log(ObjectGrabbable);
            grabbed = false;
            ObjectGrabbable.Drop();
            ObjectGrabbable = null;
        }
    }

}