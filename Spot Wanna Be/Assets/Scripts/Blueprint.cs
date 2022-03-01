﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    [SerializeField] GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
            transform.position = hit.point;
            transform.position = new Vector3 (transform.position.x, 20f, transform.position.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
            transform.position = hit.point;
            transform.position = new Vector3 (transform.position.x, 20f, transform.position.z);
        }

        if (Input.GetMouseButton(0)) {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    
    }
}
