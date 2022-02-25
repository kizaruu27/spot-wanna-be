using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Vector3 forward;
    Vector3 right;

    void Update() {
        CameraForward();
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        Vector3 direction = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 RightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        Vector3 UpMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(RightMovement + UpMovement);
        transform.forward = heading;
        transform.position += RightMovement;
        transform.position += UpMovement;
    }

    void CameraForward() {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3 (0, 90, 0)) * forward;
    }


}
