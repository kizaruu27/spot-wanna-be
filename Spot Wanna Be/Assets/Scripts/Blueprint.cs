using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    [SerializeField] GameObject prefab;
    [SerializeField] Material warningMaterial, defaultMaterial;
    [SerializeField] bool isCollide;
    Renderer rend;
    
    
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isCollide = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
            transform.position = hit.point;
            transform.position = new Vector3 (transform.position.x, 1.3f, transform.position.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
            transform.position = hit.point;
            transform.position = new Vector3 (transform.position.x, 1.3f, transform.position.z);
        }

        if (Input.GetMouseButton(0) && !isCollide) {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Object")
        {
            isCollide = true;
            rend.material = warningMaterial;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        isCollide = false;
        rend.material = defaultMaterial;
    }
        
    



}
