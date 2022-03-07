using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToPosition : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform sitPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SitDown() {
        player.position = sitPosition.transform.position;
    }
}
