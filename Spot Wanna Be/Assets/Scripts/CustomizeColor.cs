using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeColor : MonoBehaviour
{
    Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
    }

    public void ChangeColor(Material mat) {
        rend.sharedMaterial = mat;
    }

}
