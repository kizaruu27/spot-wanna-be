using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public static PlayerAnimations instance;
    Animator anim;
    public bool isSitting;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void PlayerDance()
    {
        anim.SetTrigger("Dance");
    }

    public void PlayerSit()
    {
        anim.SetTrigger("isSitting");
    }
}
