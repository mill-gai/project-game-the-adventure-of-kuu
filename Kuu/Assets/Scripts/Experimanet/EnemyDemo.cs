using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] protected private float moveSpeed;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;

    protected private Transform target; // the target is our player
    [SerializeField] protected private float distance; // enemy follow player if within this range
    private SpriteRenderer sp;
    
    private void Start() {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        Introduction();
    }
    private void Update(){
        Move();
        TurnDirection();

         
      
    }
    protected virtual void Introduction(){
        //Debug.Log("My name is " + enemyName + " HP: " + healthPoint + " moveSpeed: " + moveSpeed);
    }

    protected virtual void Move(){
        //only follow player if within the enemy's range
        if(Vector2.Distance(transform.position, target.position) < distance){
                                                    // enemys cur position, targets position
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void TurnDirection(){
        // flip enemy according to player's direction
        if(transform.position.x > target.position.x)
        {
            //Debug.Log("flipSprite");
            sp.flipX = true;
        } else {
            //Debug.Log("UnflipSprite");
            sp.flipX = false;
        }
    }

     
   
}
