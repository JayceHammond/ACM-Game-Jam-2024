using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStop : MonoBehaviour
{

    bool isTimeStopped = false;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleTimeStop();
            
        }
    }


    void ToggleTimeStop()
    {

        isTimeStopped = !isTimeStopped;

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Rewindable");
        foreach(GameObject projectile in projectiles)
        {
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = isTimeStopped; // Freeze or unfreeze the Rigidbody
            }
        }

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in platforms)
        {
            Rigidbody rb = platform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = isTimeStopped; // Freeze or unfreeze the Rigidbody
            }
        }

        
    }
}
