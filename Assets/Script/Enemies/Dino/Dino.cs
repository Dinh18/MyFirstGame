using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : Enemy
{
    public Dino(GameObject enemy, GameObject player, float speed, float ditectionRange) : base(enemy, player, speed, ditectionRange)
    {

    }
    public override void Movement()
    {
        if(DistancePlayer() <= 10) enemyRb.velocity = new Vector2(enemySpeed * Direction(), enemyRb.velocity.y);
        if(isFacingRight && Direction() == -1 )
        {
            enemy.transform.localScale = new Vector3(enemy.transform.localScale.x * -1, enemy.transform.localScale.y, enemy.transform.localScale.z);
            isFacingRight = false;
        }
        if(!isFacingRight && Direction() == 1 )
        {
            enemy.transform.localScale = new Vector3(enemy.transform.localScale.x * -1, enemy.transform.localScale.y, enemy.transform.localScale.z);
            isFacingRight = true;
        }
    }
}

    