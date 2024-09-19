using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Enemy
{
    protected GameObject enemy;
    protected GameObject player;
    protected float enemySpeed{get;set;}
    protected Rigidbody2D enemyRb;
    protected bool isFacingRight = false;
    protected float ditectionRange{get; set;}

    public Enemy(){}
    public Enemy(GameObject enemy, GameObject player, float speed, float ditectionRange)
    {
        this.enemy = enemy;
        this.player = player;
        this.enemySpeed = speed;
        this.ditectionRange = ditectionRange;
        this.enemyRb = this.enemy.GetComponent<Rigidbody2D>();
    }

    abstract public void Movement();
    public float DistancePlayer()
    {
        return (enemy.transform.position - player.transform.position).sqrMagnitude;
    }

    public int Direction()
    {
        if(DistancePlayer() <= 10)
        {
            if(enemy.transform.position.x > player.transform.position.x) return -1;
            else if(enemy.transform.position.x < player.transform.position.x) return 1;
        }
        return 0;
    }
}
