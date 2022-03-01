using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DragCamera();
    }

    void DragCamera() {
        if (Input.GetMouseButtonDown(0)) {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0)) {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log("Origin" + dragOrigin + " newPosition " + cam.ScreenPointToRay(Input.mousePosition) + " = difference " + difference);

            cam.transform.position += difference;
        }
    }
}
