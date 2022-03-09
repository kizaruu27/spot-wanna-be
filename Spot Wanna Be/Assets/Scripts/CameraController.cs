﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] float movementSpeed;
	[SerializeField] float movementTime;
	[SerializeField] float rotationAmmount;
	public Vector3 newPosition;
	public Vector3 zoomAmmount;
	public Vector3 newZoom;
	public Quaternion newRotation;
	public Transform cameraTransform;

	public Vector3 dragStartPosition;
	public Vector3 dragCurrentPosition;
	public Vector3 rotateStartPosition;
	public Vector3 rotateCurrentPosition;
	
	[Header("Choose Your Input")]
	[SerializeField] bool useMouseInput;
	[SerializeField] bool useKeyboardInput;


	void Start()
	{
		newPosition = transform.position;
		newRotation = transform.rotation;
		newZoom = cameraTransform.localPosition;
	}

	void Update()
	{
		HandleMouseInput();
		HandelMovementInput();
	}

	void HandelMovementInput() {
		if (Input.GetKey(KeyCode.UpArrow)) {
			newPosition += (transform.forward * movementSpeed);
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			newPosition += (transform.forward * -movementSpeed);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			newPosition += (transform.right * movementSpeed);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			newPosition += (transform.right * -movementSpeed);
		}

		if (Input.GetKey(KeyCode.Q)) {
			newRotation *= Quaternion.Euler(Vector3.up * rotationAmmount);
		}
		if (Input.GetKey(KeyCode.E)) {
			newRotation *= Quaternion.Euler(Vector3.up * -rotationAmmount);
		}
		if (Input.GetKey(KeyCode.R)) {
			newZoom += zoomAmmount;
		}
		if (Input.GetKey(KeyCode.F)) {
			newZoom -= zoomAmmount;
		}

		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
		cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
	}

	void HandleMouseInput() {
		if (Input.mouseScrollDelta.y != 0) {
			newZoom += Input.mouseScrollDelta.y * zoomAmmount;
		}

		 if (Input.GetMouseButtonDown(0)) {
			 Plane plane = new Plane(Vector3.up, Vector3.zero);

			 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			 float entry;

			 if (plane.Raycast(ray, out entry)) {
				 dragStartPosition = ray.GetPoint(entry);
			 }
		}

		if (Input.GetMouseButton(0)) {
			
			Plane plane = new Plane(Vector3.up, Vector3.zero);

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			 float entry;

			 if (plane.Raycast(ray, out entry)) {
				 dragCurrentPosition = ray.GetPoint(entry);

				 newPosition = transform.position + dragStartPosition - dragCurrentPosition;
			 }
		 }

		if (Input.GetMouseButtonDown(1)) {
			rotateStartPosition = Input.mousePosition;
			Cursor.visible = false;
		} else {
			Cursor.visible = true;
		}
		if (Input.GetMouseButton(1)) {
			Cursor.visible = false;
			rotateCurrentPosition = Input.mousePosition;

			Vector3 difference = rotateStartPosition - rotateCurrentPosition;

			rotateStartPosition = rotateCurrentPosition;

			newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
		} else {
			Cursor.visible = true;

		}
	}
}
