using UnityEngine;

// Comment to push lol
public class Aging : MonoBehaviour
{
    public GameObject[] objectVariations; // Array of prefabs to switch between
    private int currentIndex = 0; // Current index in the objectVariations array
    private float scaleChangeSpeed = .003f; // Speed at which the scale changes
    private GameObject currentObject; // Reference to the current prefab object
    public int timer = 0;

    void Start()
    {
        SwitchPrefab();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X)) // Press 'x' to shrink
        {
            ShrinkPrefab();
        }
        else if (Input.GetKey(KeyCode.C)) // Press 'c' to grow
        {
            GrowPrefab();
        }
        Debug.Log(timer);
    }

    void SwitchPrefab()
    {
        Vector3 scale = transform.localScale;
        if (currentObject != null)
        {
            Destroy(currentObject); // Destroy the current object if it exists
        }

        // Instantiate the new prefab at the same position and rotation as the Aging object
        currentObject = Instantiate(objectVariations[currentIndex], transform.position, transform.rotation);
        currentObject.transform.parent = transform; // Set the new object as a child of the Aging object
        currentObject.transform.localScale = scale;
    }

    void GrowPrefab()
    {
        Vector3 age = transform.localScale;
        if (age.x < 4 && age.y < 4 && age.z < 4) // Check if scale is within bounds
        {
            age += new Vector3(scaleChangeSpeed, scaleChangeSpeed, scaleChangeSpeed);
            transform.localScale = age;

            Debug.Log(age == objectVariations[currentIndex + 1].transform.localScale);
            timer += 1;
            if (objectVariations[currentIndex + 1] != null && (timer == 200 || timer == 0))
            {
                Debug.Log("In the if");
                currentIndex = Mathf.Max(currentIndex + 1, 0);
                SwitchPrefab();
                timer = 0;
            }
        }
    }

    void ShrinkPrefab()
    {
        Vector3 age = transform.localScale;
        if (age.x > 1 && age.y > 1 && age.z > 1) // Check if scale is within bounds
        {
            age -= new Vector3(scaleChangeSpeed, scaleChangeSpeed, scaleChangeSpeed);
            transform.localScale = age;
            timer -= 1;
            if (objectVariations[currentIndex - 1] != null && (timer == -200 || timer == 0))
            {
                currentIndex = Mathf.Max(currentIndex - 1, 0);
                SwitchPrefab();
                timer = 0;
            }
        }
    }
}
