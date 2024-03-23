using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour {

    [SerializeField] private Transform PlayerCameraTransform;
    [SerializeField] private Transform ObjectGrabPointTransform;
    [SerializeField] private LayerMask PickUpLayerMask;

    public ObjectsGrabbable objectGrabbable;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            if (objectGrabbable == null) {
                float PickUpDistance = 2.0f;
                if (Physics.Raycast(PlayerCameraTransform.position, PlayerCameraTransform.forward, out RaycastHit raycastHit, PickUpDistance)) {
                    Debug.Log(raycastHit.transform.TryGetComponent(out objectGrabbable));
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {
                        objectGrabbable.Grab(ObjectGrabPointTransform);
                    }
                }
            }else{
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }

}