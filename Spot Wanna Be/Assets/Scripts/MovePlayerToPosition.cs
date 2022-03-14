using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToPosition : MonoBehaviour
{
    //Animator anim;
    GameObject Player;
    PlayerAnimations anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponentInChildren<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = FindObjectOfType<PlayerAnimations>();
    }

    public void SitDown() 
    {
        anim.PlayerSit();
        Player.transform.position = transform.position;
        Player.transform.rotation = transform.rotation;
    }
}
