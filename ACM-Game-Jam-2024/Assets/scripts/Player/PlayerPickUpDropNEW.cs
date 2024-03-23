using UnityEngine;

public class PlayerPickUpDropNEW : MonoBehaviour
{
    [SerializeField] public Transform PlayerCameraTransform;
    [SerializeField] public Transform ObjectGrabPointTransform;
    [SerializeField] public LayerMask PickUpLayerMask;

    private ObjectsGrabbableNEW ObjectGrabbable;
    private bool grabbed = false;

    private void Update()
    {
        Debug.DrawRay(PlayerCameraTransform.position, PlayerCameraTransform.forward * 100f, Color.red);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!grabbed)
            {
                RaycastHit hit;
                if (Physics.Raycast(PlayerCameraTransform.position, PlayerCameraTransform.forward, out hit, 100f, PickUpLayerMask))
                {
                    ObjectsGrabbableNEW grabbable = hit.collider.GetComponent<ObjectsGrabbableNEW>();
                    if (grabbable != null)
                    {
                        ObjectGrabbable = grabbable;
                        ObjectGrabbable.Grab(ObjectGrabPointTransform);
                        grabbed = true;
                    }
                }
            }
            else
            {
                ObjectGrabbable.Drop();
                ObjectGrabbable = null;
                grabbed = false;
            }
        }
    }
}