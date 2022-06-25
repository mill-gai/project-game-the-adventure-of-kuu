using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected private float moveSpeed;
    [SerializeField] protected private float enemyScale;
    private SpriteRenderer spriteRenderer;
    protected private Rigidbody2D rigidBody;
    

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Move();
    }

     protected virtual void Move()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }
        
             
    private void OnTriggerEnter2D(Collider2D other)  
    {
        if(other.gameObject.tag == "Player"){
            bool isTired = FindObjectOfType<PlayerMovement>().getIsTired();
            if(!isTired){
                FindObjectOfType<PlayerMovement>().TakeDamage();
            }
        }
        moveSpeed = -moveSpeed;
        FlipSprite();
    }

    protected virtual void FlipSprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidBody.velocity.x))*enemyScale, enemyScale);
    }
}
