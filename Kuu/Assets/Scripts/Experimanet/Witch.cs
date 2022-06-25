using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : EnemyDemo
{
    private float moveRate = 2.0f;
    private float moveTimer;

    [SerializeField] private float minX, maxX, minY, maxY;

     // override
     protected override void Introduction()
     {
         //base.Introduction();
         //Debug.Log("I am a witch");
     }

     protected override void Move()
    {
        RandomMove();
    }

    private void RandomMove()
    {
        moveTimer += Time.deltaTime;
        if(moveTimer > moveRate)
        {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
            moveTimer = 0;
        }
    }
     
}
