using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBehaviour : MonoBehaviour
{
    private Dino dino;
    [SerializeField] GameObject player;
    [SerializeField] Animator dinoAnimator;
    void Start()
    {
        dino = new Dino(this.gameObject,player,1,10);
    }

    // Update is called once per frame
    void Update()
    {
        dino.Movement();
        dinoAnimator.SetFloat("speed",Math.Abs(dino.Direction()));
    }
}
