using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToPosition : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform sitPosition;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void SitDown() {
        anim.SetTrigger("isSitting");
        player.position = sitPosition.transform.position;
        player.rotation = sitPosition.transform.rotation;
    }
}
