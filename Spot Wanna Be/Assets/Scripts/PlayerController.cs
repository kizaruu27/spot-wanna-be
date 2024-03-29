﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    Camera cam;
    [SerializeField] float speed = 6f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float gravity = -13f;
    float velocityY = 0f;
    float turnSmoothVelocity;

    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        cam = Camera.main;
    }

    void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3 (horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f) {
            //player rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            //smoothing rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward + Vector3.up * velocityY;

            //player move
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if (controller.isGrounded) {
                velocityY = 0f;
            }

            velocityY += gravity * Time.deltaTime;            
            anim.SetBool("isWalking", true);
        } 
        else {
            anim.SetBool("isWalking", false);
        }
    }
}
