using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    Player player;
    private const string IS_WALKING = "IsWalking";
    // Start is called before the first frame update

    void Awake()
    {
        anim=GetComponent<Animator>();
        player=GetComponentInParent<Player>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(IS_WALKING,player.IsWalking());
    }
}
