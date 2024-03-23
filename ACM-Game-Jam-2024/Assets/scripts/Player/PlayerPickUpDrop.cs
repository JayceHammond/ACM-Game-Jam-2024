using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour {

    [SerializeField] private Transform PlayerCameraTransform;
    [SerializeField] private Transform ObjectGrabPointTransform;
    [SerializeField] private LayerMask PickUpLayerMask;

    private ObjectsGrabbable ObjectGrabbable;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            if (ObjectGrabbable == null) {
                float PickUpDistance = 2.0f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, PickUpDistance)) {
                    if (raycastHit.transform.TryGetComponent(out ObjectsGrabbable objectGrabbable)) {
                        objectGrabbable.Grab(ObjectGrabPointTransform);
                    }
                }
            }else{
                ObjectGrabbable.Drop();
                ObjectGrabbable = null;
            }
        }
    }

}