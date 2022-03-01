using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    bool isRotating;
    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
    }

    void Update() {
        if (isRotating) {
            if (Input.GetKey(KeyCode.L)) {
                transform.Rotate(Vector3.up * -100f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.K)) {
                transform.Rotate(Vector3.up * 100f * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                isRotating = false;
            }
        }
    }

    public void Rotate() {
        isRotating = true;
    }
}
