using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemy
{
    /*protected override void Start()
    {
        Debug.Log("fks");
        base.Start();

    } */
    protected override void Move()
    {
         rigidBody.velocity = new Vector2(0f, moveSpeed);
    }
    protected override void FlipSprite()
    {
        transform.localScale = new Vector2(enemyScale, enemyScale);
    }
}
