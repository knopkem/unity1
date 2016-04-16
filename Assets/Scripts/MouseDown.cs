using UnityEngine;
using System.Collections;

public class MouseDown : MonoBehaviour {

    int floorMask;
    float camRayLength = 1000f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
    }

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        // If we press the left mouse button, begin selection and remember the location of the mouse
        if (Input.GetMouseButtonDown(1))
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit floorHit;

            // Perform the raycast and if it hits something on the floor layer...
            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                GameObject targetObject = new GameObject();
                targetObject.transform.position = floorHit.point;

                foreach (var seletable in FindObjectsOfType<SelectableUnitComponent>())
                {
                    if (seletable.isSelected())
                    {
                        seletable.target = targetObject.transform;
                    }
                }
            }
        }
    }
    
}
