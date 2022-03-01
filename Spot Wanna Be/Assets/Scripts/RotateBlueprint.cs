using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlueprint : MonoBehaviour
{
    [SerializeField] float lerpTime = 1f;
    [SerializeField] Quaternion startQuaternion;
    // Start is called before the first frame update
    void Start()
    {
        startQuaternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            transform.rotation = Quaternion.Lerp(transform.rotation, startQuaternion, lerpTime * Time.deltaTime);
        }
    }
}
