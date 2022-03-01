using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    public void SpawnObjectBlueprint(GameObject objectBlueprint) {
        Instantiate(objectBlueprint);
    }


}
