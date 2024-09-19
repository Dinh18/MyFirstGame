using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : MonoBehaviour
{
    private Bat bat;
    [SerializeField] GameObject player;
    // private Animator batAnimator;
    void Start()
    {
        bat = new Bat(this.gameObject,player,1,20);
    }

    void Update()
    {
        bat.Movement();
    }
}
