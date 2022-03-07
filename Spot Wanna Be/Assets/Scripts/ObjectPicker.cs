using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPicker : MonoBehaviour
{
    [SerializeField] bool isSelected = false;
    [SerializeField] Transform targetObject;
    [SerializeField] Camera cam;
    Interactable interactable;
    UnityEvent onInteract;
    
    private void Update() {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.CompareTag("Object")) {
                if (hit.collider.GetComponent<Interactable>() != false) {

                    onInteract = hit.collider.GetComponent<Interactable>().onInteract;

                    if (Input.GetMouseButtonDown(0)) {
                        onInteract.Invoke();
                    }
                }
            } else {
                ResetObject();
            }
        }

    }

    void ResetObject() {
        targetObject = null;
        isSelected = false;
    }


}
